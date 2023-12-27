using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Optimus.Data;
using Optimus.Entities;

namespace Optimus.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public CategoryController(ApplicationDbContext dbContext, ILogger<CategoryController> logger)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            IEnumerable<Category> categoryList = _dbContext.Categories;

            return View(categoryList);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            _logger.LogError("create view called");
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {

            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                @TempData["success"] = "created sucessfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Category category = _dbContext.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                @TempData["success"] = "Updated sucessfully";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Category category = _dbContext.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            var category = _dbContext.Categories.Find(id);

            if (category is null)
                return NotFound();
            
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();

            @TempData["success"] = "Deleted sucessfully";

            return RedirectToAction("Index");
        }
    }
}
