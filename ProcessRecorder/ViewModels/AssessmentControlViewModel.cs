using HypnosisRising.CaseWork.Process;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HypnosisRising.ProcessRecorder.ViewModels
{
    public class AssessmentControlViewModel : BindableBase
    {
        public AssessmentControlViewModel()
        {
        }
        public AssessmentControlViewModel(
            Assessment  p_assessment )
        {
            Assessment = p_assessment;
        }

        private Assessment assessment;

        public Assessment Assessment
        {
            get { return assessment; }
            set { 
                assessment = value;
                positive = assessment.Positive;
                satisfaction = assessment.Satisfaction;
                negative = assessment.Negative;
                discomfort = Assessment.Discomfort;
            }
        }

        static double SUMin = Assessment.s_NA_SU;
        static double SUMax = Assessment.s_MaxSU;


        private string positive;
        public string Positive
        {
            get { return positive; }
            set { 
                SetProperty(ref positive, value);
                if (null != assessment)
                {
                    Satisfaction = assessment.Satisfaction;
                }
            }
        }
        private int satisfaction;
        public int Satisfaction
        {
            get { return satisfaction; }
            set { SetProperty(ref satisfaction, value); }
        }
        private string negative;
        public string Negative
        {
            get { return negative; }
            set { 
                SetProperty(ref negative, value);
                if (null != assessment)
                {
                    Discomfort = assessment.Discomfort;
                }
            }
        }
        private int discomfort;
        public int Discomfort
        {
            get { return discomfort; }
            set { SetProperty(ref discomfort, value); }
        }

        private DelegateCommand _updateCmd;
        public DelegateCommand UpdateCommand =>
                    _updateCmd ??= new DelegateCommand(OnUpdate);

        public void OnUpdate()
        {
            assessment.Positive = positive;
            assessment.Satisfaction = satisfaction;
            assessment.Negative = negative;
            assessment.Discomfort = discomfort;
        }
    }
}
