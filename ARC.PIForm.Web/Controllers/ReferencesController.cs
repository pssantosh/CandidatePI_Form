﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARC.PIForm.Model.Entities;
using ARC.PIForm.Service.Services;

namespace ARC.PIForm.Web.Controllers
{
    public class ReferencesController : Controller
    {
        private CandidateService _candidateService;
        private CandidateService CandidateService
        {
            get { return _candidateService ?? new CandidateService(); }
            set { _candidateService = value; }
        }
        // GET: References
        public ActionResult Index()
        {
            return View();
        }

        // GET: References/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: References/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: References/Create
        [HttpPost]
        public ActionResult Create(ReferenceDetails referenceDetails)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var candidateId = Session["candidateId"];
                var result = CandidateService.InsertReferenceDetails(referenceDetails, Convert.ToInt32(candidateId));

                return RedirectToAction("Create", "AdditionalDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: References/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: References/Edit/5
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

        // GET: References/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: References/Delete/5
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
