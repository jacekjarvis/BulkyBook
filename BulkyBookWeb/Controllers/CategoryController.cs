using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Models;
using BulkyBookWeb.Data;
using System.Collections;

namespace BulkyBookWeb.Controllers
{

    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;    
        }



        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;

            return View(objCategoryList);
        }

        //CREAT GET
        public IActionResult Create()
        {
            //IEnumerable<Category> objCategoryList = _db.Categories;
            //return View(objCategoryList);
            return View();
        }
    }
}
