using InsightCorp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsightCorp.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _context.Users.ToList();

            if (User.IsInRole("Executive"))
            {
                return View("Index", users);
            }

            return View();
        }
    }
}