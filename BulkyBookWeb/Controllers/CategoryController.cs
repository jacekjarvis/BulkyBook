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
        
        //----------------------------------------------------------------------------
        //CREATE GET
        public IActionResult Create()
        {
            //IEnumerable<Category> objCategoryList = _db.Categories;
            //return View(objCategoryList);
            return View();
        }

        //CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "The record was created successfully";

                return RedirectToAction("Index");
            }
            
            return View();
        }

        //----------------------------------------------------------------------------
        //EDIT GET
        public IActionResult Edit(int? id)
        {
            //IEnumerable<Category> objCategoryList = _db.Categories;
            //return View(objCategoryList);
            if (id == null || id ==0)
            {
                return NotFound();
            }

            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }


            return View(obj);
        }

        //EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "The record was updated successfully";

                return RedirectToAction("Index");

            }  
            return View();
        }


        //----------------------------------------------------------------------------
        //DELETE GET
        public IActionResult Delete(int? id)
        {
            //IEnumerable<Category> objCategoryList = _db.Categories;
            //return View(objCategoryList);
            if (id == null || id ==0)
            {
                return NotFound();
            }

            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }


            return View(obj);
        }

        //DELETE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {

            _db.Categories.Remove(obj);
            _db.SaveChanges();

            TempData["success"] = "The record was deleted successfully";
            return RedirectToAction("Index");

            //return View();
        }
    }
}
