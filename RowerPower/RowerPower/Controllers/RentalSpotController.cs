using Microsoft.AspNetCore.Mvc;
using RowerPower.Models;
using RowerPower.Repo;

namespace RowerPower.Controllers {
    public class RentalSpotController : Controller {
        private readonly IRepository<VehicleRentalSpotModel> rentalSpotRepo;

        public RentalSpotController(IRepository<VehicleRentalSpotModel> db) {
            rentalSpotRepo = db;
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleRentalSpotViewModel rs) {
            VehicleRentalSpotViewModel spot = new VehicleRentalSpotViewModel() {
                LocaleId = rs.LocaleId,
                LocaleName = rs.LocaleName,
                LocaleAddress = rs.LocaleAddress
            };

            VehicleRentalSpotModel convertedSpot = new VehicleRentalSpotModel();
            convertedSpot = convertedSpot.ToRentalSpotModel(spot);

            rentalSpotRepo.Add(convertedSpot);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            VehicleRentalSpotModel? spot = rentalSpotRepo.Get(id);
            if (spot == null) {
                return View("Index");
            }

            VehicleRentalSpotViewModel convertedSpot = new VehicleRentalSpotViewModel();
            convertedSpot = spot.ToRentalSpotViewModel(spot);

            return View(convertedSpot);
        }

        [HttpPost]
        public IActionResult Edit(VehicleRentalSpotViewModel rs) {
            VehicleRentalSpotViewModel toEdit = new VehicleRentalSpotViewModel() {
                LocaleId = rs.LocaleId,
                LocaleName = rs.LocaleName,
                LocaleAddress = rs.LocaleAddress
            };
            var convertedSpot = new VehicleRentalSpotModel();
            convertedSpot = convertedSpot.ToRentalSpotModel(toEdit);

            rentalSpotRepo.Update(convertedSpot);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            VehicleRentalSpotModel? rs = rentalSpotRepo.Get(id);

            if (rs == null) {
                RedirectToAction("Index");
            }

            VehicleRentalSpotViewModel convertedSpot = new VehicleRentalSpotViewModel();
            convertedSpot = convertedSpot.ToRentalSpotViewModel(rs);

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

            VehicleRentalSpotViewModel convertedSpot = new VehicleRentalSpotViewModel();
            convertedSpot = convertedSpot.ToRentalSpotViewModel(rs);

            return View(convertedSpot);
        }

        [HttpGet]
        public IActionResult Index() {
            List<VehicleRentalSpotViewModel> rentalsList = new List<VehicleRentalSpotViewModel>();

            foreach (var rs in rentalSpotRepo.GetAll()) {
                VehicleRentalSpotViewModel convertedSpot = new VehicleRentalSpotViewModel();
                convertedSpot = rs.ToRentalSpotViewModel(rs);

                rentalsList.Add(convertedSpot);
            }

            return View(rentalsList);
        }
    }
}