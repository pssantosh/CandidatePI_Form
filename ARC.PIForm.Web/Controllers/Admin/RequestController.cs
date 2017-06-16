using System.Web.Mvc;
using ARC.PIForm.Model.Entities;
using ARC.PIForm.Service.Services;

namespace ARC.PIForm.Web.Controllers.Admin
{
    public class RequestController : Controller
    {

        const string PIFormLink = "Piform/Create?id=";

        private CandidateService _candidateService;
        private CandidateService CandidateService
        {
            get { return _candidateService ?? new CandidateService(); }
            set { _candidateService = value; }
        }

        public ActionResult Index()
        {
            return View("Create");
        }


        public ActionResult GenerateLink(NewCandidateLinkRequest model)
        {
            ModelState.Clear();
            ViewBag.Message = CandidateService.GetCandidatePIFormUrl(ref model);
            model.PIFormLink = string.Format("{0}://{1}{2}{3}{4}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"),
                PIFormLink, model.UniqueId);
             
            return View("Create", model);
        }
    }
}