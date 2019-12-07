using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SwapiConsole
{
    /// <summary>
    /// A model to capture information of a Star Wars characters species.
    /// </summary>
    [DataContract]
    public class SpeciesModel
    {
        [DataMember(Name = "name")]
        public string SpeciesName;

        [DataMember(Name = "url")]
        public string SpeciesUrl;

    }
}
