using backoffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace backoffice.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create(Guid? id)
        {
            ViewBag.BookId = id;
            return View(new BookViewModel() { Id = id });
        }
    }
}