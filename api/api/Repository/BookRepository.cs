using api.Entity;
using api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api
{
    public class BookRepository : BaseRepository<BookEntity>
    {
        public BookRepository(DevContext dataContext) : base(dataContext)
        {

        }
    }
}
