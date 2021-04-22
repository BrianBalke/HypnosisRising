using HypnosisRising.CaseWork.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.CaseWork
{
    class Practice
    {
        private List<Therapist> hypnotists = new List<Therapist>();

        public List<Therapist> Hypnotists
        {
            get { return hypnotists; }
            set { hypnotists = value; }
        }
    }
}
