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
            var payrolls = _context.Payrolls.ToList();

            var uvm = new UserViewModel();
            uvm.Users = managerUsers;
            uvm.Payrolls = payrolls;


            if (User.IsInRole("Executive"))
            {
                uvm.Users = users;
                uvm.Payrolls = payrolls;
                return View("Index", uvm);
            }

            if (User.IsInRole("Manager"))
            {
                uvm.Users = managerUsers;
                uvm.Payrolls = payrolls;
                return View("Index", uvm);
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