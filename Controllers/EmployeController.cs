using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Covid19_Dashboard.Models;
using Covid19_Dashboard.ViewModels;

namespace Covid19_Dashboard.Controllers
{
    public class EmployeController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Employe
        public ActionResult Index()
        {
            var employes = _context.Employes.ToList();

            return View(employes);
        }

        public ActionResult Details(int id)
        {
            var empdetails = _context.Employes.SingleOrDefault(m => m.Id == id);

            if (empdetails == null)
                return HttpNotFound();
            return View(empdetails);
        }

        public ActionResult NewCovidForm()
        {
            var employename = _context.Employes.ToList();
            var covidcategory = _context.CovidCategories.ToList();
            var dutyplace = _context.DutyPlaces.ToList();
            var viewmodel = new CovidFormViewModel
            {
               
                CovidCategorys = covidcategory,
                DutyPlaces = dutyplace,
                Employes=employename
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CovidStatus covidstatus)
        {
            if(covidstatus.ID==0)
            {
              
                covidstatus.DateAdded = DateTime.Now;
                _context.CovidStatuses.Add(covidstatus);
            }

            else
            {
                var covidstatusInDb = _context.CovidStatuses.Single(m => m.ID == covidstatus.ID);
                covidstatusInDb.Employe = covidstatus.Employe;
                covidstatusInDb.CovidCategory = covidstatus.CovidCategory;
                covidstatusInDb.CovidPositiveAt500M = covidstatus.CovidPositiveAt500M;
                covidstatusInDb.CovidPositiveAt1KM = covidstatus.CovidPositiveAt1KM;
                covidstatusInDb.CovidPositiveAt2KM = covidstatus.CovidPositiveAt2KM;
                covidstatusInDb.CovidPositiveAt5KM = covidstatus.CovidPositiveAt5KM;
                covidstatusInDb.CovidPositiveAt10KM = covidstatus.CovidPositiveAt10KM;
                covidstatusInDb.AnythingReported = covidstatus.AnythingReported;
                covidstatusInDb.DutyPlace = covidstatus.DutyPlace;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}