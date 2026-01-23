using _14_library_management_system_practice.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _14_library_management_system_practice.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepo;

        public AuthController(IUserRepository userRepo) => _userRepo = userRepo;


        [HttpGet]
        public IActionResult Login()
        {
            TempData.Remove("message");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string? username, string? password)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                TempData["message"] = "Vui lòng nhập username và password";
                return View();
            }

            var userLogin = await _userRepo.GetUserByUsernameAndPasswordAsync(username, password);
            if (userLogin is null)
            {
                TempData["message"] = "Username hoặc password không hợp lệ.";
                return View();
            }

            var userJson = JsonConvert.SerializeObject(userLogin);
            HttpContext.Session.SetString("userInfo", userJson);

            if (userLogin.Role == "admin") return RedirectToAction("Index", "Book");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("userInfo");
            return RedirectToAction(nameof(Login));
        }
    }
}
