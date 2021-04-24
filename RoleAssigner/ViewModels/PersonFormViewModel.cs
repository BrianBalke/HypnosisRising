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
    public class PersonFormViewModel : BindableBase
    {

        public PersonFormViewModel()
        {
        }
        public PersonFormViewModel(Person p_person)
        {
            Person = p_person;
        }

        private Person person;

        public Person Person
        {
            get { return person; }
            set {
                SetProperty(ref person, value);
                FirstName = person.FirstName;
                LastName = person.LastName;
                Nickname = person.Nickname;
                Context = person.Context;
                Role = person.Role;
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
        private string nickName;
        public string Nickname
        {
            get { return nickName; }
            set { SetProperty(ref nickName, value); }
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
            person.FirstName = firstName;
            person.LastName = lastName;
            person.Context = context;
            person.Role = role;
        }
    }
}
