using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using MVCTestApp.Models;
using Newtonsoft.Json;
using System.Net;

namespace MVCTestApp.Controllers
{
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private List<Movie> movies = new List<Movie>() { new Movie() { Name = "RRR", Director = "Rajamuloi", Id = 1 }, new Movie() { Name = "Bahubali", Director = "Rajamuloi", Id = 2 }, new Movie() { Name = "3 idiots", Director = "RajKumar Hirani", Id = 3 } };
        // GET: MoviesController1
        /// <summary>
        /// This will return all list of movies
        /// </summary>
        /// <returns></returns>
        [Route("Ananya")]
        [HttpGet]
        public ActionResult Index()
        {
            TempData["obj"] = "This is a movie list";
            ViewBag.Title = "Welcome";
           
            return View( new MyViewModel() { Movies=movies });
        }


        [HttpGet]
        [Route("SampleAction")]
        public string SampleAction()
        {

            return JsonConvert.SerializeObject(movies);
        }

        // GET: MoviesController1/Details/5

        [HttpGet]
        [Route("details/{directorName}")]
        public ActionResult Details(string directorName)
        {
            
            List<Movie> movies = new List<Movie>() { new Movie() { Name = "RRR", Director = "Rajamuloi" , Id =1}, new Movie() { Name = "Bahubali", Director = "Rajamuloi" , Id =2}, new Movie() { Name = "3 idiots", Director = "RajKumar Hirani" , Id =3} };

            var result=movies.Where(x=>x.Director== directorName).ToList();
            return View("Index",new MyViewModel() { Movies = result });
        }

        // GET: MoviesController1/Create

        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController1/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Movie obj)
        {
            if(obj.Name.Trim().ToLower()==obj.Director.Trim().ToLower())
            {
                ModelState.AddModelError("name", "name and director name should be different");
            }
            if (ModelState.IsValid)
            {
                movies.Add(obj);
            }

            ViewData["success"] = "Movie is created.";

            return View("Index", new MyViewModel() { Movies = movies });

        }

        // GET: MoviesController1/Edit/5

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id )
        {
            Movie movie=movies.FirstOrDefault(x => x.Id == id);

            return View(movie);
        }

        // POST: MoviesController1/Edit/5

        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(Movie movie)
        {
            Movie oldItem = movies.FirstOrDefault(x => x.Id == movie.Id);

            if (oldItem != null)
            {
                oldItem.Name = movie.Name;
                oldItem.Director = movie.Director;
            }

            return View("Index", new MyViewModel() { Movies = movies });
           
        }

        // GET: MoviesController1/Delete/5

      

        // POST: MoviesController1/Delete/5

        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            Movie oldItem = movies.FirstOrDefault(x => x.Id == id);
            movies.Remove(oldItem);
            return View("Index", new MyViewModel() { Movies = movies });
        }
    }
}
