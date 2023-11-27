using Microsoft.AspNetCore.Mvc;
using Rezervari.Data;
using Rezervari.Models;

namespace Rezervari.Controllers
{
    public class MovieController : Controller
    {

        private AppDBContext dbContext;

        public MovieController(AppDBContext appDBContext)
        {
            dbContext = appDBContext;
        }

        
        public IActionResult Index()
        {
            IEnumerable<MovieModel> list = dbContext.Movies;
            return View(list);
        }

       

        public IActionResult Create()
        {
            var model = new MovieModel();
            // toate tipurile de filme pentru afisare
            ViewData["MovieTypes"] = dbContext.MovieTypes.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(MovieModel model)
        {
            if (ModelState.IsValid)
            {
                var existingMovieType = dbContext.MovieTypes.FirstOrDefault(mt => mt.Id == model.MovieTypeId);
                
                
                    model.MovieType = existingMovieType; //tipul de film
                    dbContext.Movies.Add(model);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                
                
            }

          
            ViewData["MovieTypes"] = dbContext.MovieTypes.ToList();
            return View(model);
            
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }


            MovieModel? model = dbContext.Movies.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public IActionResult DeletePost(MovieModel model)
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


            MovieModel? model = dbContext.Movies.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(MovieModel model)
        {
            dbContext.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
