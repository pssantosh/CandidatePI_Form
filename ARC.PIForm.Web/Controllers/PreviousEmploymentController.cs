using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARC.PIForm.Model.Entities;
using ARC.PIForm.Service.Services;

namespace ARC.PIForm.Web.Controllers
{
    public class PreviousEmploymentController : Controller
    {
        private CandidateService _candidateService;
        private CandidateService CandidateService
        {
            get { return _candidateService ?? new CandidateService(); }
            set { _candidateService = value; }
        }
        // GET: PreviousEmployment
        public ActionResult Index()
        {
            return View();
        }

        // GET: PreviousEmployment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PreviousEmployment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PreviousEmployment/Create
        [HttpPost]
        public ActionResult Create(PreviousEmploymentDetails previousEmploymentDetails)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var candidateId = Session["candidateId"];
                
                var result = CandidateService.InsertPreviousEmployment(previousEmploymentDetails, Convert.ToInt32(candidateId));

                return RedirectToAction("Create", "References");
            }
            catch(Exception exception)
            {
                return View();
            }
        }

        // GET: PreviousEmployment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PreviousEmployment/Edit/5
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

        // GET: PreviousEmployment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PreviousEmployment/Delete/5
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
