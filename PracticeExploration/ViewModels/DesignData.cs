using HypnosisRising.CaseWork;
using HypnosisRising.CaseWork.Common;
using HypnosisRising.CaseWork.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.PracticeExploration.ViewModels
{
    /// <summary>
    /// Psuedo-data to support view design.
    /// </summary>
    public class DesignData
    {
        public static Therapist Brian = new Therapist()
        {
            FirstName = "Brian",
            LastName = "Balke",
            Certificate = "47191603"
        };

        public static Therapist Milton = new Therapist()
        {
            FirstName = "Milton",
            LastName = "Erickson",
            Certificate = "Founder"
        };

        public static Therapist John = new Therapist()
        {
            FirstName = "John",
            LastName = "Kappas",
            Certificate = "Founder"
        };

        public static Practice Innovators = new Practice()
        {
            Name = "Innovators",
            Registration = Business.Partnership,
            Registrar = "State of California"
        };

        public static PracticeExplorerViewModel InnovatorsVM = 
            new PracticeExplorerViewModel(null, null, null)
            {
                Practice = Innovators
            };

        public static PracticeFormViewModel PracticeVM =
            new PracticeFormViewModel()
            {
                Practice = Innovators
            };
    }
}
