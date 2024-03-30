using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project_cource.Data;
using project_cource.Models;

namespace project_cource.Controllers
{
    public class ItemsController : Controller
    {

        private readonly AppDbContext _db;
        public ItemsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> itemsList = _db.Items.Include(c => c.Category).ToList();
            return View(itemsList);
        }

        public IActionResult NewPost()
        {
            CreateSelectList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewPost(Item item)
        {
            if (item.Name == "ahmed")
            {
                ModelState.AddModelError("Name", "Name can't equal ahmed");

            }
            if (ModelState.IsValid)
            {
                _db.Items.Add(item);
                _db.SaveChanges();
                TempData["sucs_data"] = "Item has been added successfully";
                return RedirectToAction("index");
            }
            else
            {
                return View(item);
            }
        }

        public void CreateSelectList(int selectId = 1)
        {
            //List<Category> categories = new List<Category>
            //{
            //    new Category (){Id = 0, Name = "Select item category, Please!."},
            //    new Category (){Id = 1, Name = "Mobiles"},
            //    new Category (){Id = 2, Name = "Computers"},
            //    new Category (){Id = 3, Name = "Electice Machiens"},
            //};
            List<Category> categories = _db.Categories.ToList();
            SelectList ListItems = new SelectList(categories, "Id", "Name", selectId);
            ViewBag.CategoryList = ListItems;
        }

        public IActionResult ReadItem(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            CreateSelectList(item.CategoryId);
            return View(item);
        }

        public IActionResult EditItem(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            CreateSelectList(item.CategoryId);
            return View(item);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditItem(Item item)
        {
            if (item.Name == "ahmed")
            {

                ModelState.AddModelError("Name", "Name can't equal ahmed");

            }
            if (ModelState.IsValid)
            {
                _db.Items.Update(item);
                _db.SaveChanges();
                TempData["sucs_data"] = "Item has been updated successfully";
                return RedirectToAction("index");
            }
            else
            {
                return View(item);
            }
        }
        [HttpPost]
        public IActionResult DeleteItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _db.Remove(item);
            _db.SaveChanges();
            TempData["sucs_data"] = "Item has been deleted successfully";
            return RedirectToAction("index");
        }
    }
}
