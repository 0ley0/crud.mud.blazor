using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.mud.blazor.Models.Entities
{
    public class Books
    {
        public int id { get; set; }
        public string title { get; set; }  
        public string author { get; set; }
        public int count { get; set; }
    }
}