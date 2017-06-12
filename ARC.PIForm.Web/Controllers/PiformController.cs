using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARC.PIForm.Model.Entities;
using ARC.PIForm.Service.Services;
using ARC.PIForm.Web.Models;

namespace ARC.PIForm.Web.Controllers
{
    public class PiformController : Controller
    {
        private CandidateService _candidateService;
        private CandidateService CandidateService
        {
            get { return _candidateService ?? new CandidateService(); }
            set { _candidateService = value; }
        }

        // GET: Piform
        public ActionResult Index()
        {
            string query = Request.QueryString["q"];
            //return View();
            return View("Create");
        }

        // GET: Piform/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Piform/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Piform/Create
        [HttpPost]
        public ActionResult Create(PersonalInformationEntity personalInformation)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var result = CandidateService.InsertCandidate(personalInformation);
                Session["candidateId"] = result.CandidateId;

                return RedirectToAction("Create", "ContactInfo", result.CandidateId);
            }
            catch(Exception exception)
            {

                return View();
            }
        }

        // GET: Piform/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Piform/Edit/5
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

        // GET: Piform/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Piform/Delete/5
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
