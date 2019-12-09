using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwapiConsole
{
    /// <summary>
    /// A controller class that maps incoming root information from API to an instance of ResultModel
    /// </summary>
    public static class ResultProcessor
    {
        public static async Task<ResultModel> GetStarWarsRootinfo(string name)
        {
            string url = $"https://swapi.co/api/people/?search={name}";
            ApiHelper.InitializeApiClient();

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ResultModel output = await response.Content.ReadAsAsync<ResultModel>();
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
