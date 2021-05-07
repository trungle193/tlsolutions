using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TLSolutions.Data;
using TLSolutions.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TLSolutions.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppIdentityDbContext _contex;
        public CategoryController(AppIdentityDbContext contex)
        {
            _contex = contex;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _contex.Categories.ToListAsync();
            return View(data);
        }


        public async Task<ActionResult> Add(Guid? Id = null)
        {
            if (Id.HasValue)
            {

                var category = await _contex.Categories.FindAsync(Id.Value);
                ViewBag.FormTitle = "Sua danh muc  " + category.Name;
                var request = new AddCategoryRequest()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Alias = category.Alias
                };
                return View(request);
            }
            else
            {
                ViewBag.FormTitle = "Them danh muc";
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add([Bind("Id,Name,Alias")] AddCategoryRequest addCategoryRequest)
        {
            if (ModelState.IsValid)
            {
                if (addCategoryRequest.Id.HasValue)
                {
                    Category c = await _contex.Categories.FindAsync(addCategoryRequest.Id.Value);
                    c.Name = addCategoryRequest.Name;
                    c.Alias = addCategoryRequest.Alias;
                }
                else
                {
                    Category c = new Category();
                    c.Id = Guid.NewGuid();
                    c.Name = addCategoryRequest.Name;
                    c.Alias = addCategoryRequest.Alias;
                    c.CreatedDate = DateTime.Now;
                    await _contex.Categories.AddAsync(c);
                }
                await _contex.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(addCategoryRequest);
        }









        public class AddCategoryRequest
        {
            public Guid? Id { get; set; }

            [Required(ErrorMessage = "vui long nhap name")]
            [MaxLength(50, ErrorMessage = "do dai khong duoc vuot qua 50")]
            [Display(Name = "Ten danh muc")]
            public string Name { get; set; }

            [Required(ErrorMessage = "vui long nhap aslis")]
            public string Alias { get; set; }
        }
    }
}
