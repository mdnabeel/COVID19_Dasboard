using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Covid19_Dashboard.Models
{
    public class CovidCategory
    {
        public byte Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}