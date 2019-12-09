using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SwapiConsole;

namespace SwapiApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        ////Default request without search Term
        //public ActionResult ApiSearch()
        //{

        //    ViewBag.Message = ("SWAPI results");
        //    return View();
        //}

        //request with search Term
        public async Task<ActionResult> ApiSearch(string searchTerm)
        {
            if (searchTerm != null && searchTerm.Length < 10)
            {
                List<PersonModel> people = new List<PersonModel>();
                ResultModel res = await ResultProcessor.GetStarWarsRootinfo(searchTerm);
                for (int i = 0; i < res.Count; i++)
                {
                    people.Add(res.results[i]);

                    //Get and set species Name.
                    string[] speciesUrl = res.results[i].Species;
                    SpeciesModel speciesRes = await SpeciesSearch(speciesUrl[0]);
                    people[i].SpeciesName = speciesRes.SpeciesName;


                    //Get and set Movie titles.
                    int movieCount = res.results[i].Movies.Length;
                    string[] movieUrls = res.results[i].Movies;
                    for (int x = 0; x < movieCount; x++)
                    {
                        string url = movieUrls[x];
                        MovieModel movieRes = await MovieSearch(url);
                        people[i].FilmsStarredIn.Add(movieRes);
                    }
                }
                return View(people);
            }
            else
            {
                return View("index");
            }
        }
        

        

        public async Task<SpeciesModel> SpeciesSearch(string url)
        {
            SpeciesModel res = await SpeciesProcessor.GetStarWarsSpeciesInfo(url);
            return res;
        }

        public async Task<MovieModel> MovieSearch(string url)
        {
            MovieModel res = await MovieProcessor.GetStarWarsMovieInfo(url);
            return res;
        }
    }
}