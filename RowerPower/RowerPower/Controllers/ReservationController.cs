using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RowerPower.Models;
using RowerPower.Repo;
using RowerPower.Validators;

namespace RowerPower.Controllers {
    public class ReservationController : Controller {
        private readonly IRepository<VehicleReservationModel, int> reservationRepo;
        private readonly IMapper mapper;
        private readonly ReservationValidator validator;

        public ReservationController(IRepository<VehicleReservationModel, int> db, IMapper mapper) {
            reservationRepo = db;
            this.mapper = mapper;
            validator = new();
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleReservationViewModel model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            VehicleReservationModel reservation = mapper.Map<VehicleReservationModel>(model);
            var result = validator.Validate(reservation);
            if (!result.IsValid) {
                return BadRequest(result.Errors);
            }
            reservationRepo.Add(reservation);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index() {
            List<VehicleReservationViewModel> reservationsList = new();

            foreach (var r in reservationRepo.GetAll()) {
                VehicleReservationViewModel reservation = mapper.Map<VehicleReservationViewModel>(r);
                reservationsList.Add(reservation);
            }
            return View(reservationsList);
        }
    }
}
