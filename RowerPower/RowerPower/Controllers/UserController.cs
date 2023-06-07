using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RowerPower.Models;
using RowerPower.Repo;

namespace RowerPower.Controllers {
    public class UserController : Controller {

        private readonly IRepository<UserModel, int> userRepo;
        private readonly IMapper mapper;

        public UserController(IRepository<UserModel, int> db, IMapper m) {
            userRepo = db;
            mapper = m;
        }

        [HttpGet]
        public IActionResult Index() {
            List<UserViewModel> users = new List<UserViewModel>();

            foreach (var u in userRepo.GetAll()) {
                UserViewModel toViewModel = mapper.Map<UserViewModel>(u);
                users.Add(toViewModel);
            }

            return View(users);
        }
    }
}
