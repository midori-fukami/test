using api.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entity
{
    public class BookEntity : Book
    {
        [Key]
        public Guid Id { get; set; }
    }
}
