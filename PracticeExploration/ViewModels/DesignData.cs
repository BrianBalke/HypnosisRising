using HypnosisRising.CaseWork;
using HypnosisRising.CaseWork.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.PracticeExploration.ViewModels
{
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
            Name = "Innovators"
        };

        public static PracticeExplorerViewModel InnovatorsVM = new PracticeExplorerViewModel()
        {
            Practice = Innovators
        };

        static DesignData()
        {
            Innovators.Hypnotists.Add(Brian);
            Innovators.Hypnotists.Add(Milton);
            Innovators.Hypnotists.Add(John);
        }
    }
}
