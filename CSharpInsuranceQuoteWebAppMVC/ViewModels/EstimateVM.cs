﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpInsuranceQuoteWebAppMVC.ViewModels
{
    public class EstimateVM
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string EAddress { get; set; }
        public int Estimation { get; set; }
    }
}