using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Covid19_Dashboard.Models
{
    public class Employe
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Employment Number")]
        public int EmpNo { get; set; }
        
    }
}