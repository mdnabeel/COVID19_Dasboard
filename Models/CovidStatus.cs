using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Covid19_Dashboard.Models
{
    public class CovidStatus
    {
        public int ID { get; set; }
        public Employe Employe { get; set; }
        public CovidCategory CovidCategory { get; set; }
        public DutyPlace DutyPlace { get; set; }
        public DateTime DateAdded { get; set; }

        [Display(Name = "COVID Category")]
        [Required]
        public byte CovidCategoryId { get; set; }

        [Display(Name = "Place of Duty")]
        [Required]
        public byte DutyPlaceId { get; set; }

        [Display(Name = "Employe Name")]
        [Required]
        public byte EmployeId { get; set; }

        [Display(Name = "COVID Positive at 500m")]
        [Required]
        public int CovidPositiveAt500M { get; set; }

        [Display(Name = "COVID Positive at 1Km")]
        [Required]
        public int CovidPositiveAt1KM { get; set; }

        [Display(Name = "COVID Positive at 2Km")]
        [Required]
        public int CovidPositiveAt2KM { get; set; }

        [Display(Name = "COVID Positive at 5Km")]
        [Required]
        public int CovidPositiveAt5KM { get; set; }

        [Display(Name = "COVID Positive at 10Km")]
        [Required]
        public int CovidPositiveAt10KM { get; set; }

        [Display(Name = "Anything you want to report (Optional)")]
        public string AnythingReported { get; set; }



    }
}