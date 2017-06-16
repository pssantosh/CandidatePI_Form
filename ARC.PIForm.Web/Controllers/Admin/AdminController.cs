using ARC.PIForm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ARC.PIForm.Web.Controllers.Admin
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCandidateList(CandidateFilterData filterData, int page = 0, int rows = 10)
        {
            List<LinkRequestCandidate> lstCandidates = new List<LinkRequestCandidate>()
            {
                new LinkRequestCandidate() { Id = 1, Name = "Santosh Shivalingappa", EmailAddress = "Santosh.Shivalingappa@gmail.com", Status = "InProgress", CreatedOn = DateTime.Now.Date },
                new LinkRequestCandidate() { Id = 2, Name = "B", EmailAddress = "d.c@c.com", Status = "Closed", CreatedOn = DateTime.Now.Date.Add(TimeSpan.FromDays(-1)) },
                new LinkRequestCandidate() { Id = 3, Name = "C", EmailAddress = "a.g@c.com", Status = "Not Started", CreatedOn = DateTime.Now.Date.Add(TimeSpan.FromDays(-1)) },
            };

            //Get candidates list here

            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = lstCandidates.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var data = lstCandidates.OrderBy(x => x.Name)
                            .Skip(pageSize * (page - 1))
                            .Take(pageSize).ToList();

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = data
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}