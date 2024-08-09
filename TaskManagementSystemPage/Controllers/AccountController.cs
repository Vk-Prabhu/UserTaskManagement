using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.BAL.Interfaces;
using TaskManagementSystem.BAL.Models;
using TaskManagementSystem.DAL.Entities;

namespace TaskManagementSystem.UI.Controllers
{
    public class AccountController : Controller
    {
        IUserDetailService _userDetail;
        IAuthService _authService;
        public AccountController(IUserDetailService userDetailService,IAuthService authService)
        {
            _authService = authService;
            _userDetail = userDetailService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            var model = new UserDetailModel();
            return View(model);
        }
        public IActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserDetailModel model)
        {
            var result = await _userDetail.AddUserDetails(model);
            return RedirectToAction(nameof(Login));

        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userDetail.LoginUser(username, password);
            if (user == null)
            {
                throw new Exception("Invalid Username or Password. Please Try Again!");
            }
            var token = _authService.GenerateToken(new UserDetailModel { UserName = username });
            Response.Cookies.Append("Authorization", "Bearer " + token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Set this to true if using HTTPS
                Expires = DateTime.UtcNow.AddHours(1)
            });
            return RedirectToAction(nameof(Dashboard));
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View("Dashboard");
        }
        public IActionResult Logout()
        {
            if (Request.Cookies.ContainsKey("Authorization"))
            {
                Response.Cookies.Delete("Authorization");
            }
            return RedirectToAction(nameof(Login));
        }
    }
}
