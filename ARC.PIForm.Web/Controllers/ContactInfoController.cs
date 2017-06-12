using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARC.PIForm.Model.Entities;
using ARC.PIForm.Service.Services;

namespace ARC.PIForm.Web.Controllers
{
    public class ContactInfoController : Controller
    {
        private CandidateService _candidateService;
        private CandidateService CandidateService
        {
            get { return _candidateService ?? new CandidateService(); }
            set { _candidateService = value; }
        }
        // GET: ContactInfo
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContactInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactInfo/Create
        [HttpPost]
        public ActionResult Create(ContactInfoEntity contactInfoEntity)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var candidateId = Session["candidateId"];

                var result = CandidateService.InsertContactDetails(contactInfoEntity, Convert.ToInt32(candidateId));

                return RedirectToAction("Create", "EducationDetails");
            }
            catch(Exception exception)
            {
                return View();
            }
        }

        // GET: ContactInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactInfo/Edit/5
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

        // GET: ContactInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactInfo/Delete/5
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
