using MVC.Data;
using MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace MVC.Controllers
{
    public class BirdController : Controller
    {
        private readonly ApplicationDBContext _db;

        public BirdController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable <Bird> allBird = _db.Birds;

            return View(allBird);
        }

        // GET Method
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent CSRF
        public IActionResult Create(Bird obj)
        {
            Random rand = new Random();

            // Generate random R, G, B
            int red = rand.Next(0, 256);
            int green = rand.Next(0, 256);
            int blue = rand.Next(0, 256);

            Bird Breed = new Bird(red, green, blue);

            var count = _db.Birds.Count();
            if (count < 50)
            {
                _db.Birds.Add(Breed);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // Sell Out
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Search Data
            var obj = _db.Birds.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Birds.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
