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
using TLSolutions.Data;
using TLSolutions.Entities.Identity;

namespace TLSolutions.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RolesController : Controller
    {
        public class AddRoleRequest
        {
            public Guid Id { get; set; }
            [Required(ErrorMessage = "Vui long nhap ten role")]
            public string Name { get; set; }
        }

        public class AddRoleClaimRequest
        {
            [Required(ErrorMessage = "Vui long chon claim")]
            public string SelectedClaim { get; set; }

            [Required]
            public string RoleId { get; set; }
        }

        public class RemoveRoleClaimsRequest
        {
            public string ClaimValue { get; set; }
            public string RoleId { get; set; }
        }

        private readonly AppIdentityDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;
        public RolesController(AppIdentityDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        //[Authorize("ViewRole")]
        [Authorize("ViewRole")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roles.OrderBy(x => x.Name).AsNoTracking().ToListAsync());
        }

        [Authorize("ViewRole")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appRole = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
            if (appRole == null)
            {
                return NotFound();
            }

            return View(appRole);
        }

        [Authorize("CreateRole")]
        // GET: Admin/Roles/Create
        public IActionResult Create()
        {
            ViewBag.FormTitle = "Add New Role";
            return View();
        }

        [Authorize("EditRole")]
        // GET: Admin/Roles/Create
        public async Task<IActionResult> Edit([FromRoute] Guid Id)
        {
            var appRole = await _roleManager.FindByIdAsync(Id.ToString());
            AddRoleRequest addRoleRequest = new AddRoleRequest();
            addRoleRequest.Id = appRole.Id;
            addRoleRequest.Name = appRole.Name;
            ViewBag.FormTitle = "Edit Role : " + appRole.Name;
            return View("Create", addRoleRequest);
        }

        // POST: Admin/Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("CreateRole")]
        public async Task<IActionResult> Create([Bind("Id,Name")] AddRoleRequest request, [FromRoute] Guid? Id = null)
        {
            if (ModelState.IsValid)
            {
                if (!Id.HasValue)
                {
                    AppRole appRole = new AppRole();
                    appRole.Id = Guid.NewGuid();
                    appRole.Name = request.Name;
                    appRole.NormalizedName = request.Name;
                    IdentityResult addRoleResult = await _roleManager.CreateAsync(appRole);
                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(AddRoleRequest.Name), addRoleResult.Errors.FirstOrDefault()?.Description);
                    }
                }
                else
                {
                    AppRole appRole = await _roleManager.FindByIdAsync(request.Id.ToString());
                    appRole.Name = request.Name;
                    appRole.NormalizedName = request.Name;
                    IdentityResult addRoleResult = await _roleManager.UpdateAsync(appRole);
                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(AddRoleRequest.Name), addRoleResult.Errors.FirstOrDefault()?.Description);
                    }
                }
            }
            return View(request);
        }



        // GET: Admin/Roles/Delete/5
        [Authorize("DeleteRole")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appRole = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appRole == null)
            {
                return NotFound();
            }

            return View(appRole);
        }

        // POST: Admin/Roles/Delete/5
        [Authorize("DeleteRole")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var appRole = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(appRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Claims()
        {
            var claims = await _context.PermissionClaims.OrderBy(x => x.Name).AsNoTracking().ToListAsync();
            return View(claims);
        }

        public async Task<IActionResult> AddPermissionClaim()
        {
            return View();
        }

        public async Task<IActionResult> RoleClaims(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            var claims = await _roleManager.GetClaimsAsync(role);

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
            ViewBag.RoleId = Id;
            return View(claims.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddClaimToRole(AddRoleClaimRequest addRoleClaimRequest)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(addRoleClaimRequest.RoleId);
                await _roleManager.AddClaimAsync(role, new System.Security.Claims.Claim(Configurations.Identity.Constants.PERMISSION, addRoleClaimRequest.SelectedClaim));
            }
            else
            {
                TempData["Message"] = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).FirstOrDefault();
            }
            return RedirectToAction(nameof(RoleClaims), new
            {
                Id = addRoleClaimRequest.RoleId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveClaimFromRole(RemoveRoleClaimsRequest request)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            var clamToDelete = claims.FirstOrDefault(x => x.Type == Configurations.Identity.Constants.PERMISSION && x.Value == request.ClaimValue);
            if (clamToDelete != null)
            {
                await _roleManager.RemoveClaimAsync(role, clamToDelete);
            }
            return RedirectToAction(nameof(RoleClaims), new
            {
                Id = request.RoleId
            });
        }
    }
}
