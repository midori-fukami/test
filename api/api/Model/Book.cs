using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Book
    {
        public string Code { get; set; }
        
        public string Name { get; set; }
        
        public int Count { get; set; }
    }
}
