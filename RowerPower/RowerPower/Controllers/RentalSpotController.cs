using Microsoft.AspNetCore.Mvc;
using RowerPower.Models;
using RowerPower.Repo;
using AutoMapper;

namespace RowerPower.Controllers {
    public class RentalSpotController : Controller {
        private readonly IRepository<VehicleRentalSpotModel, int> rentalSpotRepo;
        private readonly IMapper mapper;

        public RentalSpotController(IRepository<VehicleRentalSpotModel, int> db, IMapper mapper) {
            rentalSpotRepo = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleRentalSpotViewModel rs) {
            VehicleRentalSpotModel convertedSpot = mapper.Map<VehicleRentalSpotModel>(rs);

            rentalSpotRepo.Add(convertedSpot);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            VehicleRentalSpotModel? spot = rentalSpotRepo.Get(id);
            if (spot == null) {
                return View("Index");
            }

            VehicleRentalSpotViewModel convertedSpot = mapper.Map<VehicleRentalSpotViewModel>(spot);

            return View(convertedSpot);
        }

        [HttpPost]
        public IActionResult Edit(VehicleRentalSpotViewModel rs) {
            VehicleRentalSpotModel convertedSpot = mapper.Map<VehicleRentalSpotModel>(rs);

            rentalSpotRepo.Update(convertedSpot);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            VehicleRentalSpotModel? rs = rentalSpotRepo.Get(id);

            if (rs == null) {
                RedirectToAction("Index");
            }

            VehicleRentalSpotViewModel convertedSpot = mapper.Map<VehicleRentalSpotViewModel>(rs);

            return View(convertedSpot);
        }

        [HttpPost]
        public IActionResult Delete(VehicleRentalSpotViewModel rs) {
            rentalSpotRepo.Delete(rs.LocaleId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id) {
            VehicleRentalSpotModel? rs = rentalSpotRepo.Get(id);

            if (rs == null) {
                RedirectToAction("Index");
            }

            VehicleRentalSpotViewModel convertedSpot = mapper.Map<VehicleRentalSpotViewModel>(rs);

            return View(convertedSpot);
        }

        [HttpGet]
        public IActionResult Index() {
            List<VehicleRentalSpotViewModel> rentalsList = new();

            foreach (var rs in rentalSpotRepo.GetAll()) {
                VehicleRentalSpotViewModel convertedSpot = mapper.Map<VehicleRentalSpotViewModel>(rs);

                rentalsList.Add(convertedSpot);
            }

            return View(rentalsList);
        }
    }
}