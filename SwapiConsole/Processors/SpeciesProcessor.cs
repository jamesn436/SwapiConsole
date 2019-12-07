using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwapiConsole

{
    /// <summary>
    /// A controller class that maps incoming JSON data from API to an instance of SpeciesModel.
    /// </summary>
    public static class SpeciesProcessor
    {
        private static List<SpeciesModel> SpeciesCache = new List<SpeciesModel>();


        /// <summary>
        /// Makes a request to the SWAPI api for information about a Star Wars characters species
        /// Maps and returns requested information as an instance of SpeciesModel
        /// </summary>
        /// <param name="url">the url that points to the species information of a star wars character on the SWAPI Api</param>
        /// <returns></returns>
        public static async Task<SpeciesModel> GetStarWarsSpeciesInfo(string url)
        {
            SpeciesModel cached = SpeciesCache.Where(x => x.SpeciesUrl == url).FirstOrDefault();

            if (cached != null)
            {
                return cached;
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SpeciesModel output = await response.Content.ReadAsAsync<SpeciesModel>();
                    SpeciesCache.Add(output);
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
