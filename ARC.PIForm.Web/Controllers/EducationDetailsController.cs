using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARC.PIForm.Model.Entities;
using ARC.PIForm.Service.Services;

namespace ARC.PIForm.Web.Controllers
{
    public class EducationDetailsController : Controller
    {
        private CandidateService _candidateService;
        private CandidateService CandidateService
        {
            get { return _candidateService ?? new CandidateService(); }
            set { _candidateService = value; }
        }
        // GET: EducationDetails
        public ActionResult Index()
        {
            return View();
        }

        // GET: EducationDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EducationDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationDetails/Create
        [HttpPost]
        public ActionResult Create(EducationalDetailsEntity educationalDetails)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var candidateId = Session["candidateId"];

                var result = CandidateService.InsertEducationalDetails(educationalDetails, Convert.ToInt32(candidateId));

                return RedirectToAction("Create", "PreviousEmployment");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        // GET: EducationDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EducationDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EducationDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EducationDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
