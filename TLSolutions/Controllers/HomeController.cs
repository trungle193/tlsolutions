using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TLSolutions.Areas.Identity;
using TLSolutions.Data;
using TLSolutions.Models;

namespace TLSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppUserManager _userManager;
        public HomeController(ILogger<HomeController> logger, AppUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            ClaimsPrincipal claimsPrincipal = this.User;
            var roles = claimsPrincipal.Claims
                         .Where(c => c.Type == ClaimTypes.Role)
                         .Select(c => c.Value)
                         .ToList();

            var currnetUser = await _userManager.GetUserAsync(HttpContext.User);
            var claims = await _userManager.GetClaimsAsync(currnetUser);
            return View();
        }

        [HttpGet("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet("Logout")]
        [Authorize]
        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
