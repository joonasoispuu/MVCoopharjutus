using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCoopkrodus.Models
{
    public class CountryGDP
    {
        public List<CountryGDP> Countries { get; set; }
        public SelectList Region { get; set; }
        public string CountryRegion { get; set; }
        public string SearchString { get; set; }
    }
}