using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SwapiConsole
{
    /// <summary>
    /// Helper class to create a new instance of HttpClient and to set the header to request JSON format.
    /// </summary>
    public static class ApiHelper
    {
        public static HttpClient ApiClient;

        /// <summary>
        /// Initializes a new HttpClient to request JSON format.
        /// </summary>
        public static void InitializeApiClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }


}
