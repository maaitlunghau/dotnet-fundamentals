using _12_dto_automapper_announcement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _12_dto_automapper_announcement.Controllers
{
    public class AuthController : Controller
    {
        public readonly IUserRepository _repo;
        public AuthController(IUserRepository repo) => _repo = repo;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _repo.GetUserLoginAsync(email, password);
            if (user == null)
            {
                TempData["message"] = "Email hoặc password không hợp lệ!";
                return View();
            }

            // method 01: parse core
            // var userJson = System.Text.Json.JsonSerializer.Serialize(user);

            // method 02: using Newtonsoft packages
            var userJson = JsonConvert.SerializeObject(user); // parse Object -> JSON string
            HttpContext.Session.SetString("userInfo", userJson); // save JSON string to Session

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // HttpContext.Session.Clear(); // clear session
            HttpContext.Session.Remove("userInfo");

            return RedirectToAction(nameof(Login));
        }
    }
}
