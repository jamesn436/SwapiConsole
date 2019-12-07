using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwapiConsole
{
    public static class MovieProcessor
    {
        /// <summary>
        /// A controller class that maps incoming JSON data from API to an instance of MovieModel.
        /// </summary>
        private static List<MovieModel> MovieCache = new List<MovieModel>();

        /// <summary>
        /// Makes a request to the SWAPI api for information on the movies a Star Wars character 
        /// has appeared in.
        /// Maps and returns requested information as an instance of MovieModel
        /// </summary>
        /// <param name="movieurl">the url that points to the Movie information of a star wars character on the SWAPI Api</param>
        /// <returns></returns>
        public static async Task<MovieModel> GetStarWarsMovieInfo(string movieurl)
        {
            MovieModel cached = MovieCache.Where(x => x.MovieUrl == movieurl).FirstOrDefault();

            if (cached != null)
            {
                return cached;
            }
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(movieurl))
            {
                if (response.IsSuccessStatusCode)
                {
                    MovieModel output = await response.Content.ReadAsAsync<MovieModel>();
                    MovieCache.Add(output);
                    return output;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
