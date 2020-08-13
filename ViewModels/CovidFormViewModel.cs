using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Covid19_Dashboard.Models;

namespace Covid19_Dashboard.ViewModels
{
    public class CovidFormViewModel
    {
        public IEnumerable<CovidCategory> CovidCategorys { get; set; }
        public IEnumerable<DutyPlace> DutyPlaces { get; set; }
        public IEnumerable<Employe> Employes { get; set; }
        public CovidStatus CovidStatus { get; set; }
        public string Title
        {
            get
            {
                if (CovidStatus != null && CovidStatus.ID != 0)
                    return "Edit Covid Status";

                return "New COVID Entry";
            }
        }

    }
}