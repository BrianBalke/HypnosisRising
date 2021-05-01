using HypnosisRising.CaseWork.Process;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HypnosisRising.ProcessRecorder.ViewModels
{
    public class StateControlViewModel : BindableBase
    {
        public StateControlViewModel()
        {
        }
        public StateControlViewModel(
            State       p_state )
        {
            State = p_state;
        }

        private State state;
        private AssessmentControlViewModel physicalVM = new AssessmentControlViewModel();
        private AssessmentControlViewModel emotionalVM = new AssessmentControlViewModel();
        private AssessmentControlViewModel mentalVM = new AssessmentControlViewModel();
        private AssessmentControlViewModel spiritualVM = new AssessmentControlViewModel();

        public AssessmentControlViewModel PhysicalVM
        {
            get { return physicalVM; }
        }
        public AssessmentControlViewModel EmotionalVM
        {
            get { return emotionalVM; }
        }
        public AssessmentControlViewModel MentalVM
        {
            get { return mentalVM; }
        }
        public AssessmentControlViewModel SpiritualVM
        {
            get { return spiritualVM; }
        }


        public State State
        {
            get { return state; }
            set { 
                state = value;
                Description = state.Description;
                Observation = state.Observation;
                physicalVM.Assessment = state.Physical;
                emotionalVM.Assessment = state.Emotional;
                MentalVM.Assessment = state.Mental;
                SpiritualVM.Assessment = state.Spiritual;
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
        private string observation;
        public string Observation
        {
            get { return observation; }
            set { SetProperty(ref observation, value); }
        }

        private DelegateCommand _updateCmd;
        public DelegateCommand UpdateCommand =>
                    _updateCmd ??= new DelegateCommand(OnUpdate);

        public void OnUpdate()
        {
            state.Description = description;
            state.Observation = observation;
            physicalVM.OnUpdate();
            emotionalVM.OnUpdate();
            mentalVM.OnUpdate();
            spiritualVM.OnUpdate();
        }
    }
}
