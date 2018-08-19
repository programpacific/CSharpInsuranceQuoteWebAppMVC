using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharpInsuranceQuoteWebAppMVC.Models;

namespace CSharpInsuranceQuoteWebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EstimateCalc(string fname, string lname, string eaddress, string dobirth, int vyear, string vmake, string vmodel, string aconviction, int bconvictionqty, string coveragetype)
        {
            try
            {
                double priceCalc = 50.00;
                
                DateTime ageCalc = DateTime.Parse(dobirth);
                int userDob = DateTime.Today.Year - ageCalc.Year;

                if (userDob < 25)
                {
                    priceCalc += 25;
                }
                if (userDob < 18)
                {
                    priceCalc += 100;
                }
                if (userDob > 100)
                {
                    priceCalc += 25;
                }
                if (vyear < 2000)
                {
                    priceCalc += 25;
                }
                if (vyear > 2015)
                {
                    priceCalc += 25;
                }
                if (vmake.ToUpper() == "PORSCHE")
                {
                    priceCalc += 25;
                }
                if (vmake.ToUpper() == "911 CARRERA" || vmodel.ToUpper() == "911CARRERA")
                {
                    priceCalc += 25;
                }
                for (int i = 0; i < bconvictionqty; i++)
                {
                    priceCalc += 10;
                }
                if (aconviction.ToUpper() == "YES")
                {                    
                    priceCalc *= 1.25;
                }
                if (coveragetype.ToUpper() == "FULL" || coveragetype == "FULL COVERAGE")
                {                    
                    priceCalc *= 1.5;
                }

                using (EstimateEntities db = new EstimateEntities())
                {
                    var quote = new Quote();
                    quote.FName = fname;
                    quote.LName = lname;
                    quote.EAddress = eaddress;
                    quote.Estimation = (int)priceCalc;

                    db.Quotes.Add(quote);
                    db.SaveChanges();
                }
                return View("Success");
            }
            catch(Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }
    }
}