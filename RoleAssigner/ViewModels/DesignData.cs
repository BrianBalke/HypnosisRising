using HypnosisRising.CaseWork.Common;
using HypnosisRising.CaseWork.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.RoleAssigner.ViewModels
{
    class DesignData
    {
        //***** PersonForm

        public static Person Shaw =
            new Person()
            {
                FirstName = "George",
                LastName = "Shaw",
                Nickname = "Jr",
                Context = CaseWork.Common.Environment.Friendship,
                Role = "Intellectual"
            };

        public static PersonFormViewModel ShawVM =
            new PersonFormViewModel()
            {
                Person = Shaw
            };

        //***** ContactForm

        public static Contact Headroom =
            new Contact()
            {
                FirstName = "Max",
                LastName = "Headroom",
                Nickname = "Grazie",
                Context = CaseWork.Common.Environment.Social,
                Role = "Virtual Avatar",
                EMail = "max@dead.edu",
                Phone = "818-818-8188",
                HasText = true
            };

        public static ContactFormViewModel HeadroomVM =
            new ContactFormViewModel() { Contact = Headroom };

        //***** ClientForm

        public static Contact Fluffy =
            new Contact()
            {
                FirstName = "Fluffy",
                LastName = "Bird",
                Nickname = "Pootie Pie",
                Context = CaseWork.Common.Environment.Family,
                Role = "Nestmate",
                EMail = "fluffy@wb.com",
                Phone = "818-444-8723",
                HasText = false
            };

        public static Contact Sylvester =
            new Contact()
            {
                FirstName = "Sylvester",
                LastName = "Cat",
                Nickname = "Putty",
                Context = CaseWork.Common.Environment.Career,
                Role = "Stalker",
                EMail = "sylvester@wb.com",
                Phone = "310-333-9023",
                HasText = true
            };

        public static Location Cage =
            new Location()
            {
                Street1 = "100 Acorn St",
                Street2 = "Gilded Cage",
                District = "New York",
                Region = "NY",
                MailCode = "09223",
                Country = "USA"
            };

        public static Client Tweety =
            new Client()
            {
                FirstName = "Tweey",
                LastName = "Bird",
                EMail = "tweety@sb.com",
                Phone = Fluffy.Phone,
                HasText = Fluffy.HasText,
                DateOfBirth = DateTime.Parse("Aug 15,1957"),
                HomeAddress = Cage,
                Partner = Fluffy,
                EmergencyContact = Sylvester,
                BillingRate = 225
            };

        public static ClientFormViewModel TweetyVM =
            new ClientFormViewModel() { Client = Tweety };

        //***** ClientForm

        public static Location Office = new Location()
        {
            Street1="1500 Palma Dr.",
            Street2="Suite 131",
            District="Ventura",
            Region="CA",
            MailCode="93003",
            Country="USA"
        };

        public static Therapist Brian = new Therapist()
        {
            FirstName = "Brian",
            LastName = "Balke",
            Nickname = "Professor",
            EMail = "brian@hypnosisrising.com",
            Phone = "805-775-6716",
            HasText = true,
            OfficeAddress=Office,
            OfficeIsMailing=true,
            Certifier="Hypnotherapists Union 472",
            Certificate= "47191603",
            Insurer="American Professional",
            PolicyNumber="BA8902365"
        };

        public static TherapistFormViewModel BrianVM =
            new TherapistFormViewModel(null,null)
            {
                Therapist = Brian
            };
        
    }
}
