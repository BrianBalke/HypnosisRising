using HypnosisRising.CaseWork.Common;
using HypnosisRising.CaseWork.Roles;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HypnosisRising.RoleAssigner.ViewModels
{
    public class ClientFormViewModel : BindableBase
    {
        public ClientFormViewModel()
        {

        }
        public ClientFormViewModel(
            Client p_client)
        {
            Client = p_client;
        }

        ContactFormViewModel contactVM = new ContactFormViewModel();
        public ContactFormViewModel ContactVM { get => contactVM; }
        ContactFormViewModel partnerVM = new ContactFormViewModel();
        public ContactFormViewModel PartnerVM { get => partnerVM; }
        ContactFormViewModel emergencyVM = new ContactFormViewModel();
        public ContactFormViewModel EmergencyVM { get => emergencyVM; }

        private Client client;
        public Client Client
        {
            get { return client; }
            set
            {
                client = value;
                contactVM.Contact = client;

                DateOfBirth = client.DateOfBirth;
                HomeAddress = client.HomeAddress;
                Partner = client.Partner;
                EmergencyContact = client.EmergencyContact;
                BillingRate = client.BillingRate;

                partnerVM.Contact = partner;
                emergencyVM.Contact = emergencyContact;
            }
        }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { SetProperty(ref dateOfBirth, value); }
        }
        private Location homeAddress;
        public Location HomeAddress
        {
            get { return homeAddress; }
            set { SetProperty(ref homeAddress, value); }
        }
        private Contact partner;
        public Contact Partner
        {
            get { return partner; }
            set { SetProperty(ref partner, value); }
        }
        private Contact emergencyContact;
        public Contact EmergencyContact
        {
            get { return emergencyContact; }
            set { SetProperty(ref emergencyContact, value); }
        }
        private int billingRate;
        public int BillingRate
        {
            get { return billingRate; }
            set { SetProperty(ref billingRate, value); }
        }

        private DelegateCommand _updateCmd;
        public DelegateCommand UpdateCommand =>
                    _updateCmd ??= new DelegateCommand(OnUpdate);

        public void OnUpdate()
        {
            client.DateOfBirth = DateOfBirth;
            client.HomeAddress = HomeAddress;
            client.BillingRate = BillingRate;

            contactVM.OnUpdate();
            partnerVM.OnUpdate();
            emergencyVM.OnUpdate();
        }
    }
}
