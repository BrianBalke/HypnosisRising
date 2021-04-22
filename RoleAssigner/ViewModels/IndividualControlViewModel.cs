using HypnosisRising.CaseWork.Common;
using HypnosisRising.CaseWork.Roles;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypnosisRising.RoleAssigner.ViewModels
{
    public class IndividualControlViewModel : BindableBase
    {

        public IndividualControlViewModel()
        {
        }
        public IndividualControlViewModel(Individual p_individual)
        {
            Individual = p_individual;
        }

        private Individual individual;

        public Individual Individual
        {
            get { return individual; }
            set { 
                individual = value;
                firstName = individual.FirstName;
                lastName = individual.LastName;
                context = individual.Context;
                role = individual.Role;
            }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }
        private CaseWork.Common.Environment context;
        public CaseWork.Common.Environment Context
        {
            get { return context; }
            set { SetProperty(ref context, value); }
        }
        private string role;
        public string Role
        {
            get { return role; }
            set { SetProperty(ref role, value); }
        }

        private DelegateCommand _updateCmd;
        public DelegateCommand UpdateCommand =>
                    _updateCmd ??= new DelegateCommand(OnUpdate);

        public void OnUpdate()
        {
            individual.FirstName = firstName;
            individual.LastName = lastName;
            individual.Context = context;
            individual.Role = role;
        }
    }
}
