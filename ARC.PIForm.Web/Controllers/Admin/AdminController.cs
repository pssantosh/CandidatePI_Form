using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARC.PIForm.Model.Entities;
using ARC.PIForm.Service.Services;

namespace ARC.PIForm.Web.Controllers.Admin
{
    public class AdminController : Controller
    {
        private CandidateService _candidateService;
        private CandidateService CandidateService
        {
            get { return _candidateService ?? new CandidateService(); }
            set { _candidateService = value; }
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCandidateList(CandidateFilterData filterData, int page = 0, int rows = 10)
        {
            List<CandidateDetail> lstCandidates = CandidateService.GetCandidateSearchList(filterData);

            //Get candidates list here

            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = lstCandidates.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var data = lstCandidates.OrderBy(c => c.CreatedOn)
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