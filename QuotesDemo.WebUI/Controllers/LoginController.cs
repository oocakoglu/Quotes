using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using QuotesDemo.Core.Models;
using QuotesDemo.Core.Services;
using QuotesDemo.WebUI.Models;

namespace QuotesDemo.WebUI.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginVM loginVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Notification = new Notification(mType.Danger, "Please make sure all field entered");
                    return View();
                }

                var result = await _userService.CheckLogin(loginVM.UserName, loginVM.Password);
                if (result.Status == false)
                {
                    ViewBag.Notification = new Notification(mType.Warning, result.Message);
                    return View();
                }

                string _session = result.ToJson();
                HttpContext.Session.SetString("UserSession", _session);
                return Redirect("~/Quote");
                
            }
            catch (Exception ex)
            {
                ViewBag.Notification = new Notification(mType.Danger, ex.Message);
                return View();
            }
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterVM registerVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Notification = new Notification(mType.Danger, "Please make sure all field entered");
                    return View();
                }

          
                if (registerVM.Password != registerVM.RePassword)
                {
                    ViewBag.Notification = new Notification(mType.Danger, "Please make sure all field entered");
                    return View();
                }

                var result = await _userService.Register(registerVM.UserName, registerVM.Password);
                if (result.Status == false)
                {
                    ViewBag.Notification = new Notification(mType.Danger, result.Message);
                    return View();
                }

                ViewBag.Notification = new Notification(mType.Success, "User created succesfully. After activated your user, you can use system");
                return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Redirect("/Login");
        }

    }
}
