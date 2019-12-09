using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SwapiConsole
{
    /// <summary>
    /// A model to capture information of a Star Wars character.
    /// </summary>
    [DataContract]
    public class PersonModel
    {


        [DataMember(Name = "name")]
        public string FullName { get; set; }

        [DataMember(Name = "gender")]
        public string Gender { get; set; }

        [DataMember(Name = "films")]
        public string[] Movies { get; set; }

        [DataMember(Name = "species")]
        public string[] Species { get; set; }

        public string SpeciesName { get; set; }

        public List<MovieModel> FilmsStarredIn = new List<MovieModel>();
    }
}
