using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TLSolutions.Areas.Identity;
using TLSolutions.Data;
using TLSolutions.Entities.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TLSolutions.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly AppIdentityDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly AppUserManager _userManager;
        public UsersController(AppIdentityDbContext context, RoleManager<AppRole> roleManager, AppUserManager userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public class RoleSelection

        {
            public AppRole Role { get; set; }
            public bool IsSelected { get; set; }
            public RoleSelection(AppRole role)
            {
                Role = role;
            }
        }

        public class AddUserClaimRequest
        {
            [Required(ErrorMessage = "Vui long chon claim")]
            public string SelectedClaim { get; set; }

            [Required]
            public string UserId { get; set; }
        }

        public class RemoveUserClaimsRequest
        {
            public string ClaimValue { get; set; }
            public string UserId { get; set; }
        }

        // GET: /<controller>/
        [Authorize("ViewUser")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).OrderBy(x => x.UserName).AsNoTracking().ToListAsync();
            return View(users);
        }

        [Authorize("DeleteUser")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(Id.ToString());
                if (User.Identity.Name == user.UserName)
                {
                    throw new Exception("Cannot delete you self");
                }
                await _userManager.DeleteAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> EditRole(Guid Id)
        {
            var allRoles = await _roleManager.Roles.OrderBy(x => x.Name).AsNoTracking().Select(x => new RoleSelection(x)).ToListAsync();
            var currentRoles = await _roleManager.Roles.Where(x => x.UserRoles.Any(x => x.UserId == Id)).AsNoTracking().ToListAsync();

            foreach (var selectedRole in currentRoles)
            {
                var inALlRole = allRoles.SingleOrDefault(x => x.Role.Id == selectedRole.Id);
                inALlRole.IsSelected = true;
            }
            ViewBag.AllRoles = allRoles;
            ViewBag.UserId = Id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateRoles(string[] selectedRoles, Guid Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            var oldUserRoles = await _context.UserRoles.Where(x => x.UserId == Id).Select(x => x.Role.Name).ToListAsync();
            await _userManager.RemoveFromRolesAsync(user, oldUserRoles);
            await _userManager.AddToRolesAsync(user, selectedRoles);
            TempData["Message"] = "Cập nhật thành công";
            return RedirectToAction(nameof(EditRole), new { Id = Id });
        }




        public async Task<IActionResult> Claims(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            var claims = await _userManager.GetClaimsAsync(user);

            var permissions = await _context.PermissionClaims.OrderBy(x => x.Name).AsNoTracking().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id
            }).ToListAsync();

            permissions.Insert(0, new SelectListItem()
            {
                Value = null,
                Text = "Select claim"
            });

            ViewBag.PermissionOptions = permissions;
            ViewBag.UserName = user.UserName;
            ViewBag.UserId = Id;
            return View(claims.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddClaimToRole(AddUserClaimRequest addRoleClaimRequest)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(addRoleClaimRequest.UserId);
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim(Configurations.Identity.Constants.PERMISSION, addRoleClaimRequest.SelectedClaim));
            }
            else
            {
                TempData["Message"] = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).FirstOrDefault();
            }
            return RedirectToAction(nameof(Claims), new
            {
                Id = addRoleClaimRequest.UserId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveClaimFromRole(RemoveUserClaimsRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            var claims = await _userManager.GetClaimsAsync(user);
            var clamToDelete = claims.FirstOrDefault(x => x.Type == Configurations.Identity.Constants.PERMISSION && x.Value == request.ClaimValue);
            if (clamToDelete != null)
            {
                await _userManager.RemoveClaimAsync(user, clamToDelete);
            }
            return RedirectToAction(nameof(Claims), new
            {
                Id = request.UserId
            });
        }

    }

}
