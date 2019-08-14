using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Collections.Generic;
using RecipeBox.Models;
using System.Threading.Tasks;
using System.Security.Claims;

namespace RecipeBox.Controllers
{

    [Authorize]
    public class RecipesController : Controller
    {

        private readonly RecipeBoxContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public RecipesController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Recipes
                .Where(x => x.User.Id == currentUser.Id).ToList());
        }

        public ActionResult Create()
        {
            // Selectlist type - need DataList? Is it a thing?
            ViewBag.TagId = new SelectList(_db.Tags, "TagId");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Recipe recipe, int TagId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            recipe.User = currentUser;
            _db.Recipes.Add(recipe);
            if (TagId != 0)
            {
                _db.TagRecipe.Add(new TagRecipe() { TagId = TagId, RecipeId = recipe.RecipeId});
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // public ActionResult Details(int id)
        // {

        // }


    }
}