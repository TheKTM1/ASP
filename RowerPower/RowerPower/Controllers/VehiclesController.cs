using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RowerPower.Models;
using RowerPower.Repo;
using AutoMapper;

namespace RowerPower.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IRepository<VehicleModel> vehicleRepo;
        private readonly IRepository<VehicleTypeModel> vehicleTypeRepo;
        private readonly IMapper mapper;

        public VehiclesController(IRepository<VehicleModel> vehicleRepository, IRepository<VehicleTypeModel> vehicleTypeRepository, IMapper mapper) {
            vehicleRepo = vehicleRepository;
            vehicleTypeRepo = vehicleTypeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create() {
            var vList = vehicleTypeRepo.GetAll();

            ViewBag.VehicleTypes = new SelectList(vList, "VehicleTypeId", "VehicleTypeName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleDetailViewModel vehicle) {

            VehicleTypeModel? vType = vehicleTypeRepo.Get(vehicle.Type.VehicleTypeId);
            if (vType is null) {
                throw new Exception("null");
            }

            VehicleModel v = new() {
                VehicleId = vehicle.Id,
                Name = vehicle.Name,
                Type = vType,
                Producer = vehicle.Producer,
                Price = vehicle.Price,
                Height = vehicle.Height,
                Weight = vehicle.Weight,
                Color = vehicle.Color,
                Description = vehicle.Description
            };

            vehicleRepo.Add(v);

            return RedirectToAction("VehicleItemView");
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            VehicleModel? vehicle = vehicleRepo.Get(id);

            if (vehicle == null) {
                return RedirectToAction("VehicleItemView");
            }

            VehicleDetailViewModel convertedVehicle = mapper.Map<VehicleDetailViewModel>(vehicle);

            var vList = vehicleTypeRepo.GetAll();
            ViewBag.VehicleTypes = new SelectList(vList, "VehicleTypeId", "VehicleTypeName");

            return View(convertedVehicle);
        }

        [HttpPost]
        public IActionResult Edit(VehicleDetailViewModel vehicle) {
            VehicleTypeModel? vType = vehicleTypeRepo.Get(vehicle.Type.VehicleTypeId);
            if (vType is null) { 
                throw new Exception("null");
            }

            VehicleModel editedVehicle = new() {
                VehicleId = vehicle.Id,
                Name = vehicle.Name,
                Type = vType,
                Producer = vehicle.Producer,
                Price = vehicle.Price,
                Height = vehicle.Height,
                Weight = vehicle.Weight,
                Color = vehicle.Color,
                Description = vehicle.Description
            };

            vehicleRepo.Update(editedVehicle);

            return RedirectToAction("VehicleItemView");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            VehicleModel? vehicle = vehicleRepo.Get(id);
            if (vehicle == null) {
                return RedirectToAction("VehicleItemView");
            }

            VehicleDetailViewModel convertedVehicle = mapper.Map<VehicleDetailViewModel>(vehicle);

            return View(convertedVehicle);
        }

        [HttpPost]
        public IActionResult Delete(VehicleDetailViewModel vehicle) {
            vehicleRepo.Delete(vehicle.Id);
            return RedirectToAction("VehicleItemView");
        }

        [HttpGet]
        public IActionResult VehicleItemView() {

            List<VehicleItemViewModel> vehicles = new();

            foreach (var v in vehicleRepo.GetAll()) {

                VehicleItemViewModel convertedVehicle = mapper.Map<VehicleItemViewModel>(v);

                vehicles.Add(convertedVehicle);
            }

            return View(vehicles);
        }

        [HttpGet]
        public IActionResult VehicleDetailView(int id) {
            VehicleModel? vehicle = vehicleRepo.Get(id);

            if (vehicle == null) {
                return RedirectToAction("VehicleItemView");
            }

            VehicleDetailViewModel convertedVehicle = mapper.Map<VehicleDetailViewModel>(vehicle);

            return View(convertedVehicle);
        }
    }
}
