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
    /// <summary>
    /// Binding wrapper for <see cref="Person"/>. Values are cached locally
    /// until <see cref="UpdateCommand"/> is triggered.
    /// </summary>
    /// <remarks>To be extended for model navigation support.</remarks>
    public class PersonFormViewModel : BindableBase
    {
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public PersonFormViewModel()
        {
        }

        private Person person;

        /// <summary>
        /// Target instance. Setter transfer properties to the local cache.
        /// </summary>
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
        /// <summary>
        /// Two-way binding for FirstName.
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }
        private string lastName;
        /// <summary>
        /// Two-way binding for LastName.
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }
        private string nickName;
        /// <summary>
        /// Two-way binding for Nickname.
        /// </summary>
        public string Nickname
        {
            get { return nickName; }
            set { SetProperty(ref nickName, value); }
        }
        private CaseWork.Common.Environment context;
        /// <summary>
        /// Two-way binding for relationship Context.
        /// </summary>
        public CaseWork.Common.Environment Context
        {
            get { return context; }
            set { SetProperty(ref context, value); }
        }
        private string role;
        /// <summary>
        /// Two-way binding for relationship role. E.g. - "Mother,"
        /// "Coach," etc.
        /// </summary>
        public string Role
        {
            get { return role; }
            set { SetProperty(ref role, value); }
        }

        private DelegateCommand _updateCmd;
        /// <summary>
        /// Triggers transfer of cached values back to instance.
        /// </summary>
        public DelegateCommand UpdateCommand =>
                    _updateCmd ??= new DelegateCommand(OnUpdate);

        /// <summary>
        /// Transfers cached values to instance.
        /// </summary>
        public void OnUpdate()
        {
            person.FirstName = firstName;
            person.LastName = lastName;
            person.Context = context;
            person.Role = role;
        }
    }
}
