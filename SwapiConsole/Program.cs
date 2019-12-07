
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;

namespace SwapiConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ApiHelper.InitializeApiClient();
            string anotherLookUp = "";

            do
            {
                Console.WriteLine("Enter an name");
                string searchTerm = Console.ReadLine();

                try
                {
                    
                    ResultModel res = await ResultProcessor.GetStarWarsRootinfo(searchTerm);
                    Console.WriteLine($"{res.Count } Matches found");
                    for (int i =0; i<res.Count; i++)
                    {
                        
                        if (res.Count != 0)
                        { 
                            Console.WriteLine($"{res.results[i].FullName}");
                            Console.WriteLine($"{res.results[i].Gender}");

                            string[] speciesUrl = res.results[i].Species;
                            SpeciesModel speciesmodel = await SpeciesProcessor.GetStarWarsSpeciesInfo(speciesUrl[0]);
                            Console.WriteLine(speciesmodel.SpeciesName);


                            string[] movies = res.results[i].Movies;
                            for (i = 0; i<movies.Length; i++)
                            {
                                MovieModel movieModel = await MovieProcessor.GetStarWarsMovieInfo(movies[i]);
                                Console.WriteLine(movieModel.MovieName);
                            }
                        }

                        else
                        {
                            Console.WriteLine("No matches found.");
                        }
                        
                    }
                    
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                Console.WriteLine("Look up another person Yes/No: ");
                anotherLookUp = Console.ReadLine();
                Console.Clear();
            } while (anotherLookUp.ToLower() == "yes"); 
                
            
            }

        

        

        

        

       


   


    }

   
}
