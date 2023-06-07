using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using RowerPower.Repo;
using AutoMapper;
using RowerPower.Models;
using RowerPower.Areas.Admin.Models;

namespace RowerPower.Areas.Admin.Controllers {
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller {
        private readonly IRepository<UserModel, string> userRepo;
        private readonly IMapper mapper;
        private readonly UserManager<UserModel> userManager;

        public AdminController(IRepository<UserModel, string> userRepo, IMapper mapper, UserManager<UserModel> userManager) {
            this.userRepo = userRepo;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult UserList() {
            List<UserModel> usersM = userRepo.GetAll();
            List<UserViewModel> usersVM = new();
            foreach (var user in usersM) {
                usersVM.Add(mapper.Map<UserViewModel>(user));
            }

            return View(usersVM);
        }

        [HttpGet]
        public async Task<IActionResult> UserEdit(string id) {

            if (id is null) {
                throw new Exception("null");
            }

            UserModel user = await userManager.FindByIdAsync(id);
            UserViewModel uvm = mapper.Map<UserViewModel>(user);
            List<string> userRoles = (await userManager.GetRolesAsync(user)).ToList();

            UserEditViewModel uevm = new UserEditViewModel() {
                user = uvm,
                userRoles = userRoles
            };

            return View(uevm);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(string id, UserEditForm userEditForm) {
            UserModel user = await userManager.FindByIdAsync(id);
            List<string> rolesToAddOrder = new() { "Administrator", "Operator", "Użytkownik" };

            //usunięcie wszystkich ról użytkownika
            var userRoles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, userRoles);

            //dodanie ról wpisanych w userEditForm.userRoles
            if (userEditForm.userRoles is null) throw new Exception("xd");
            foreach (var role in rolesToAddOrder) {
                if (userEditForm.userRoles.Contains(role)) {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

            return RedirectToAction("UserList");
        }
    }
}
