using InsightCorp.Models;
using Microsoft.AspNet.Identity;
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
            var id = User.Identity.GetUserId();
            var users = _context.Users.ToList();
            var managerUsers = _context.Users.Where(u => u.ManagerId == id).ToList();

            if (User.IsInRole("Executive"))
            {
                return View("Index", users);
            }

            if (User.IsInRole("Manager"))
            {
                return View("Index", managerUsers);
            }

            return View();
        }

        public ActionResult Delete(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            _context.Users.Remove(user);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}