using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SwapiConsole
{
    /// <summary>
    /// A model to capture the root information from the API
    /// </summary>
    public class ResultModel
    {
            [DataMember(Name = "count")]
            public int Count { get; set; }
            public object next { get; set; }
            public object previous { get; set; }
            public PersonModel[] results { get; set; }
        
    }
}
