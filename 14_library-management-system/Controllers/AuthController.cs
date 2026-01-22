using _14_library_management_system.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _14_library_management_system.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;
        private readonly IUserRepository _userRepository;

        public AuthController(IAuthRepository repo, IUserRepository userRepository)
        {
            _repo = repo;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            TempData.Remove("message");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string? username, string? password)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                TempData["message"] = "Vui lòng nhập username và password!";
                return View();
            }

            var user = await _userRepository.GetUserByUsernameAndPasswordAsync(username, password);
            if (user == null)
            {
                TempData["message"] = "Username hoặc mật khẩu không hợp lệ!";
                return View();
            }

            var userJson = JsonConvert.SerializeObject(user);
            HttpContext.Session.SetString("userInfo", userJson);

            if (username == "maaitlunghau" && password == "admin@123")
                return RedirectToAction("Index", "Book");

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("userInfo");
            return RedirectToAction(nameof(Login));
        }
    }
}
