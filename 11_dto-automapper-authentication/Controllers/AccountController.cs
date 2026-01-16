using _11_dto_automapper_authentication.DTOs;
using _11_dto_automapper_authentication.Models;
using AspNetCoreGeneratedDocument;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace _11_dto_automapper_authentication.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        public AccountController(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userLoginJson = HttpContext.Session.GetString("userLogin");
            if (!string.IsNullOrEmpty(userLoginJson))
            {
                var userLogin = JsonConvert.DeserializeObject<Account>(userLoginJson ?? string.Empty);
                if (userLogin?.Role == "ADMIN")
                {
                    var accounts = await _dbContext.Accounts.ToListAsync();

                    // map Account sang UserDTO (thay vì dùng Select ở đây như cách cũ)
                    var UserDtoList = _mapper.Map<List<UserDTO>>(accounts);

                    return View(UserDtoList);
                }

                return RedirectToAction(nameof(Create));
            }

            TempData["message"] = "Please login to continue";
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(userDTO);
            }

            // map UserDTO sang Account lại, vì:
            // -- vì lí thuyết: nếu AddSync(userDTO) là sai, vì DTO chỉ là object vận chuyển dữ liệu thôi chứ kh có thao tác với Database
            // -- vì model Account khác với model UserDTO, dù cho model có khớp thì về lí thuyết đã sai rồi!
            var userMappered = _mapper.Map<Account>(userDTO);

            await _dbContext.Accounts.AddAsync(userMappered);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _dbContext.Accounts.FirstOrDefaultAsync(x =>
                x.Email == email && x.Password == password
            );

            if (user != null)
            {
                // parse bằng cơm (core)
                // var userJson = System.Text.Json.JsonSerializer.Serialize(user);

                // hoặc sử dụng thư viện Newtonsoft để parse JSON
                var userJson = JsonConvert.SerializeObject(user);
                HttpContext.Session.SetString("userLogin", userJson);

                if (user.Role == "ADMIN") return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(Create));
            }

            TempData["message"] = "Invalid email or password";
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // HttpContext.Session.Remove("userLogin");
            // hoặc
            HttpContext.Session.Clear(); // cách này thì xoá hết tất cả

            return RedirectToAction(nameof(Login));
        }
    }
}