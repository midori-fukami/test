using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Business;
using api.Entity;
using api.Proxy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Produces("application/json")]
    [Route("api/Book")]
    public class BookController : BaseController
    {
        private readonly BookBusiness _business;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="business"></param>
        public BookController(BookBusiness business)
        {
            _business = business;
        }

        /// <summary>
        /// Get list of Books
        /// </summary>
        /// <param name="payload"></param>
        /// <returns>List</returns>
        [ProducesResponseType(typeof(List<BookProxy>), 200)]
        [HttpGet("list")]
        public IActionResult Get()
        {
            return RunDefault(() => Ok(_business.Get()));
        }

        /// <summary>
        /// Get Book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BookEntity</returns>
        [ProducesResponseType(typeof(BookEntity), 200)]
        [HttpGet("{id}")]
        public Task<IActionResult> Get(Guid id)
        {
            return RunDefaultAsync(async () => Ok(await _business.Get(id)));
        }
        
        /// <summary>
        /// Update a Book by payload
        /// </summary>
        /// <param name="payload"></param>
        /// <returns>true or false</returns>
        [ProducesResponseType(typeof(bool), 200)]
        [HttpPost("create")]
        public IActionResult Create(BookProxy payload)
        {
            return RunDefault(() => Ok(_business.AddBook(payload)));
        }

        /// <summary>
        /// Update a Book by payload
        /// </summary>
        /// <param name="payload"></param>
        /// <returns>true or false</returns>
        [ProducesResponseType(typeof(bool), 200)]
        [HttpPost("{id}/update")]
        public IActionResult Update(Guid id, BookEntity payload)
        {
            return RunDefault(() => Ok(_business.UpdateBook(id, payload)));
        }

        /// <summary>
        /// Deactive a Book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true or false</returns>
        [ProducesResponseType(typeof(bool), 200)]
        [HttpPost("delete/{id}")]
        public Task<IActionResult> Delete(Guid id)
        {
            return RunDefaultAsync(async () => Ok(await _business.Delete(id)));
        }
    }
}