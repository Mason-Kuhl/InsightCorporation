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
            var ptoList = _context.Ptoes.Where(p => p.UserId == id).ToList();

            return View(ptoList);
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

            _context.Ptoes.Add(requestedPto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EmpRequests()
        {
            if (User.IsInRole("Manager"))
            {
                var id = User.Identity.GetUserId();
                var ptoList = _context.Ptoes.Where(p => p.ManagerId == id).ToList();

                var pendingList = new List<Pto>();
                foreach(var request in ptoList)
                {
                    if (request.IsApproved == null)
                    {
                        pendingList.Add(request);
                    }
                }

                return View(pendingList);
            }
            return HttpNotFound();
        }

        public ActionResult Approve(int id)
        {
            var request = _context.Ptoes.Find(id);
            request.IsApproved = true;

            _context.SaveChanges();

            return RedirectToAction("EmpRequests");
        }

        public ActionResult Deny(int id)
        {
            var request = _context.Ptoes.Find(id);
            request.IsApproved = false;

            _context.SaveChanges();

            return RedirectToAction("EmpRequests");
        }
    }
}