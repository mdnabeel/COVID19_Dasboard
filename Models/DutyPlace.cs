using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Covid19_Dashboard.Models
{
    public class DutyPlace
    {
        public byte Id { get; set; }
        public string PlaceOfDuty { get; set; }
    }
}