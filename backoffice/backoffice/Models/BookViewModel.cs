using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backoffice.Models
{
    public class BookViewModel
    {
        public Guid? Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}