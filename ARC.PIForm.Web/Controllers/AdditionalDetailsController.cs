using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARC.PIForm.Model.Entities;
using ARC.PIForm.Service.Services;

namespace ARC.PIForm.Web.Controllers
{
    public class AdditionalDetailsController : Controller
    {
        private CandidateService _candidateService;
        private CandidateService CandidateService
        {
            get { return _candidateService ?? new CandidateService(); }
            set { _candidateService = value; }
        }
        // GET: AdditionalDetails
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdditionalDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdditionalDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdditionalDetails/Create
        [HttpPost]
        public ActionResult Create(AdditionalDetailsEntity additionalDetailsEntity)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var candidateId = Session["candidateId"];

                var result = CandidateService.InsertAdditionalDetails(additionalDetailsEntity, Convert.ToInt32(candidateId));

                return View();
            }
            catch(Exception exception)
            {
                return View();
            }
        }

        // GET: AdditionalDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdditionalDetails/Edit/5
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

        // GET: AdditionalDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdditionalDetails/Delete/5
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
