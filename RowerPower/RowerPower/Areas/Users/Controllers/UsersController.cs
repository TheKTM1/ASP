using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using RowerPower.Repo;
using AutoMapper;
using RowerPower.Models;
using RowerPower.Areas.Admin.Models;

namespace RowerPower.Areas.Admin.Controllers {
    [Area("Users")]
    [Authorize]
    public class UsersController : Controller {
        private readonly IRepository<UserModel, string> userRepo;
        private readonly IRepository<VehicleModel, int> vehicleRepo;
        private readonly IRepository<VehicleRentalSpotModel, int> vehiclePointsRepo;
        private readonly IRepository<VehicleReservationModel, int> reservationsRepo;

        private readonly IMapper mapper;
        private readonly UserManager<UserModel> userManager;

        public UsersController(IRepository<UserModel, string> userRepo, IRepository<VehicleModel, int> vehicleRepo, IRepository<VehicleRentalSpotModel, int> vehiclePointsRepo, IRepository<VehicleReservationModel, int> reservationsRepo, IMapper mapper, UserManager<UserModel> userManager) {
            this.userRepo = userRepo;
            this.vehicleRepo = vehicleRepo;
            this.vehiclePointsRepo = vehiclePointsRepo;
            this.reservationsRepo = reservationsRepo;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        private async Task<UserModel>? GetLoggedInUser() {
            if (User?.Identity?.IsAuthenticated ?? false) {
                try {
                    return await userManager.FindByNameAsync(User?.Identity?.Name ?? "");
                } catch {
                    return null;
                }
            }
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            UserModel? loggedInUser = await GetLoggedInUser();
            if (loggedInUser == null) throw new Exception("ni ma usera, a jakimś cudem tu wszedł");
            List<VehicleReservationModel> reservations = reservationsRepo.GetAll().Where(x => x.User.Id == loggedInUser.Id).ToList();
            return View(reservations);
        }

        [HttpGet]
        public async Task<IActionResult> MakeReservation() {
            UserReservationFormGET _makeReservationGET = new();

            List<VehicleRentalSpotModel> punkty = vehiclePointsRepo.GetAll();
            List<VehicleRentalSpotViewModel> punktyVM = new();
            List<VehicleModel> pojazdy = vehicleRepo.GetAll();
            List<VehicleItemViewModel> pojazdyVM = new();
            foreach (var punkt in punkty) {
                punktyVM.Add(mapper.Map<VehicleRentalSpotViewModel>(punkt));
            }
            foreach (var pojazd in pojazdy) {
                pojazdyVM.Add(mapper.Map<VehicleItemViewModel>(pojazd));
            }

            _makeReservationGET.AutoPointy = punktyVM;
            _makeReservationGET.AutoAuto = pojazdyVM;

            return View(_makeReservationGET);
        }

        [HttpPost]
        public async Task<IActionResult> MakeReservation(UserReservationFormPOST reservationData) {
            UserModel? loggedInUser = await GetLoggedInUser();
            if (loggedInUser == null) throw new Exception("a kto to?");

            VehicleReservationModel reservation = new() {
                LocaleId = vehiclePointsRepo.Get(reservationData.ReserwejszynPojntAjdi) ?? throw new Exception("ebło"),
                Vehicle = vehicleRepo.Get(reservationData.WyporzyczanePedały) ?? throw new Exception("jebło"),
                ReservationDateStart = reservationData.DataWypozyczenia
            };

            reservationsRepo.Add(reservation);
            return RedirectToAction("Index");
        }
    }
}
