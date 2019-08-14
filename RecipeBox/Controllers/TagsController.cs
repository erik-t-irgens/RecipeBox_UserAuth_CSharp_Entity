using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Collections.Generic;
using RecipeBox.Models;
using RecipeBox.ViewModels;
using System.Threading.Tasks;
using System.Security.Claims;

namespace RecipeBox.Controllers
{
    [Authorize]
    public class TagsController : Controller
    {
     private readonly RecipeBoxContext _db;
     private readonly UserManager<ApplicationUser> _userManager;

     public TagsController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
     {
         _userManager = userManager;
         _db = db;
     }

     public async Task<ActionResult> Index()
     {
          var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Tags
                .Where(x => x.User.Id == currentUser.Id).ToList());
     }


    }
}