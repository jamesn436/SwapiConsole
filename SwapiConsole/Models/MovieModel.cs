using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SwapiConsole

{
    /// <summary>
    /// A model to capture information of Movies that Star Wars characters have appeared.
    /// </summary>
    [DataContract]
    public class MovieModel
    {
        [DataMember(Name = "title")]
        public string MovieName;

        [DataMember(Name = "url")]
        public string MovieUrl;

    }
}
