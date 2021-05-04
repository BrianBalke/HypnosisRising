using HypnosisRising.CaseWork.Roles;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace HypnosisRising.RoleAssigner.ViewModels
{
    /// <summary>
    /// Binding wrapper for properties specific to <see cref="Contact"/>. 
    /// Values are cached locally until <see cref="UpdateCommand"/> is triggered.
    ///
    /// Publishes a <see cref="PersonFormViewModel"/> to wrap inherited 
    /// properties.
    /// </summary>
    /// <remarks>To be extended for model navigation support.</remarks>
    public class ContactFormViewModel : BindableBase
    {
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public ContactFormViewModel()
        {
        }

        PersonFormViewModel personVM = new PersonFormViewModel();
        /// <summary>
        /// Wrapper for inherited properties.
        /// </summary>
        public PersonFormViewModel PersonVM { get => personVM; }

        private Contact contact;
        /// <summary>
        /// Wrapped instance. Setter caches properties to local storage,
        /// and injects the instance into <see cref="PersomVM"/>.
        /// </summary>
        public Contact Contact
        {
            get { return contact; }
            set { 
                contact = value;
                personVM.Person = contact;
                EMail = contact.EMail;
                Phone = contact.Phone;
                HasText = contact.HasText;
            }
        }

        private string email;
        /// <summary>
        /// Two-way binding for EMail.
        /// </summary>
        public string EMail
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
        private string phone;
        /// <summary>
        /// Two-way binding for Phone.
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }
        private bool hasText;
        /// <summary>
        /// Two-way binding for HasText.
        /// </summary>
        public bool HasText
        {
            get { return hasText; }
            set { SetProperty(ref hasText, value); }
        }

        private DelegateCommand _updateCmd;
        /// <summary>
        /// Command to trigger transfter edited values to instance.
        /// </summary>
        public DelegateCommand UpdateCommand =>
                    _updateCmd ??= new DelegateCommand(OnUpdate);

        /// <summary>
        /// Tranfsers local values to the instance, including values cached
        /// in <see cref="PersonVM"/>.
        /// </summary>
        public void OnUpdate()
        {
            contact.EMail = email;
            contact.Phone = phone;
            contact.HasText = hasText;

            personVM.OnUpdate();
        }
    }
}
