using System;
using System.Collections.Generic;
using System.Text;

namespace SwapiConsole.Processors
{
    public static class PersonProcessor
    {
        public static void CreatePerson(string fullName, string gender,string[] species, string[] films)
        {
            PersonModel data = new PersonModel
            {
                FullName = fullName,
                Gender = gender,
                Species = species,
                Movies = films
            };
        }
    }
}
