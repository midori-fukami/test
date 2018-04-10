using api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Proxy
{
    public class BookProxy : Book
    {
        public Guid? Id { get; set; }
    }
}
