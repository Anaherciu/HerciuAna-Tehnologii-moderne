using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rezervari.Data;
using Rezervari.Models;

namespace Rezervari.Controllers
{
    public class MovieTypeController : Controller
    {
        private AppDBContext dbContext;

        public MovieTypeController(AppDBContext appDBContext)
        {
            dbContext=appDBContext;
        }

        public IActionResult Index()
        {
            IEnumerable<MovieTypeModel> list=dbContext.MovieTypes;
            return View(list);
        }

        public IActionResult Create()
        {
            MovieTypeModel model = new MovieTypeModel();
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(MovieTypeModel model)
        {
            dbContext.Add(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }


            MovieTypeModel? model= dbContext.MovieTypes.FirstOrDefault(x => x.Id == id);
            if (model==null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public IActionResult DeletePost(MovieTypeModel model)
        {
            dbContext.Remove(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }


            MovieTypeModel? model = dbContext.MovieTypes.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(MovieTypeModel model)
        {
            dbContext.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
