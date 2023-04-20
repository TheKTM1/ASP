using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using RowerPower.Models;
using RowerPower.Repo;

namespace RowerPower.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IRepository<VehicleModel> vehicleRepo;
        private readonly IRepository<VehicleTypeModel> vehicleTypeRepo;

        public VehiclesController(IRepository<VehicleModel> db, IRepository<VehicleTypeModel> vehicleTypeRepository) {
            vehicleRepo = db;
            vehicleTypeRepo = vehicleTypeRepository;
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleDetailViewModel vehicle) {

            var newVehicle = new VehicleDetailViewModel() {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Type = vehicle.Type,
                Producer = vehicle.Producer,
                Price = vehicle.Price,
                Height = vehicle.Height,
                Weight = vehicle.Weight,
                Color = vehicle.Color,
                Description = vehicle.Description
            };

            VehicleModel convertedVehicle = newVehicle.ToVehicleModel(newVehicle);

            vehicleRepo.Add(convertedVehicle);

            return RedirectToAction("VehicleItemView");
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            VehicleModel? vehicle = vehicleRepo.Get(id);

            if (vehicle == null) {
                return RedirectToAction("VehicleItemView");
            }

            VehicleDetailViewModel convertedVehicle = new VehicleDetailViewModel();
            convertedVehicle = convertedVehicle.ToVehicleDetailViewModel(vehicle);

            return View(convertedVehicle);
        }

        [HttpPost]
        public IActionResult Edit(VehicleDetailViewModel vehicle) {
            var editedVehicle = new VehicleDetailViewModel() {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Type = vehicle.Type,
                Producer = vehicle.Producer,
                Price = vehicle.Price,
                Height = vehicle.Height,
                Weight = vehicle.Weight,
                Color = vehicle.Color,
                Description = vehicle.Description
            };

            VehicleModel convertedVehicle = new VehicleModel();
            convertedVehicle = editedVehicle.ToVehicleModel(editedVehicle);

            vehicleRepo.Update(convertedVehicle);

            return RedirectToAction("VehicleItemView");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            VehicleModel? vehicle = vehicleRepo.Get(id);
            if (vehicle == null) {
                return RedirectToAction("VehicleItemView");
            }

            VehicleDetailViewModel convertedVehicle = new VehicleDetailViewModel();
            convertedVehicle = convertedVehicle.ToVehicleDetailViewModel(vehicle);

            return View(convertedVehicle);
        }

        [HttpPost]
        public IActionResult Delete(VehicleDetailViewModel vehicle) {
            vehicleRepo.Delete(vehicle.Id);
            return RedirectToAction("VehicleItemView");
        }

        [HttpGet]
        public IActionResult VehicleItemView() {

            List<VehicleItemViewModel> vehicles = new List<VehicleItemViewModel>();

            foreach (var v in vehicleRepo.GetAll()) {

                var newVehicle = new VehicleModel() {
                    VehicleId = v.VehicleId,
                    Name = v.Name,
                    Type = v.Type,
                    Producer = v.Producer,
                    Price = v.Price
                };

                VehicleItemViewModel convertedVehicle = new VehicleItemViewModel();
                convertedVehicle = convertedVehicle.ToVehicleItemViewModel(newVehicle);

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

            VehicleDetailViewModel convertedVehicle = new VehicleDetailViewModel();
            convertedVehicle = convertedVehicle.ToVehicleDetailViewModel(vehicle);

            return View(convertedVehicle);
        }
    }
}
