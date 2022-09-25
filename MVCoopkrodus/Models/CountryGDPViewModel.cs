using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCoopkrodus.Models
{
    public class CountryGDPViewModel
    {
        public List<GDP> Countries { get; set; }
        public SelectList Regions { get; set; }
        public string CountryRegion { get; set; }
        public string SearchString { get; set; }
    }
}