using InsightCorp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsightCorp.Controllers
{
    public class PTOController : Controller
    {
        private ApplicationDbContext _context;

        public PTOController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: PTO
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var ptoList = _context.PtoRequests.Where(p => p.UserId == id).ToList();

            return View();
        }

        [HttpGet]
        public ActionResult NewRequest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewRequest(Pto pto)
        {
            var id = User.Identity.GetUserId();
            var user = _context.Users.Find(id);
            var managerId = user.ManagerId;
            var date = pto.RequestedDayOff;

            var requestedPto = new Pto();
            requestedPto.UserId = id;
            requestedPto.ManagerId = managerId;
            requestedPto.RequestedDayOff = pto.RequestedDayOff;
            requestedPto.IsApproved = null;

            _context.PtoRequests.Add(requestedPto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}