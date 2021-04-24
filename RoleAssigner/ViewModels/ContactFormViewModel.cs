using HypnosisRising.CaseWork.Roles;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace HypnosisRising.RoleAssigner.ViewModels
{
    public class ContactFormViewModel : BindableBase
    {
        public ContactFormViewModel()
        {
        }
        public ContactFormViewModel(
            Contact     p_contact)
        {
            Contact = p_contact;
        }

        PersonFormViewModel personVM = new PersonFormViewModel();
        public PersonFormViewModel PersonVM { get => personVM; }

        private Contact contact;
        public Contact Contact
        {
            get { return contact; }
            set { 
                contact = value;
                personVM.Person = contact;
                EMail = contact.EMail.ToString();
                Phone = contact.Phone;
                HasText = contact.HasText;
            }
        }

        private string email;
        public string EMail
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }
        private bool hasText;
        public bool HasText
        {
            get { return hasText; }
            set { SetProperty(ref hasText, value); }
        }

        private DelegateCommand _updateCmd;
        public DelegateCommand UpdateCommand =>
                    _updateCmd ??= new DelegateCommand(OnUpdate);

        public void OnUpdate()
        {
            contact.EMail = email;
            contact.Phone = phone;
            contact.HasText = hasText;

            personVM.OnUpdate();
        }
    }
}
