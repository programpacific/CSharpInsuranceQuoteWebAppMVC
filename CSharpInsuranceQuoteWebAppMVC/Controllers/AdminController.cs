using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharpInsuranceQuoteWebAppMVC.Models;
using CSharpInsuranceQuoteWebAppMVC.ViewModels;

namespace CSharpInsuranceQuoteWebAppMVC.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            using (EstimateEntities db = new EstimateEntities())
            {
                var EstimateVMs = new List<EstimateVM>();
                foreach(var quote in db.Quotes)
                {
                    var estimateVM = new EstimateVM();
                    estimateVM.Id = quote.Id;
                    estimateVM.FName = quote.FName;
                    estimateVM.LName = quote.LName;
                    estimateVM.EAddress = quote.EAddress;
                    estimateVM.Estimation = (int)quote.Estimation;
                    EstimateVMs.Add(estimateVM);
                }
                return View(EstimateVMs);

            }
        }
    }
}