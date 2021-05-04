using HypnosisRising.CaseWork.Common;
using HypnosisRising.CaseWork.Roles;
using NUnit.Framework;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace TestDataContract
{
    public class Roles_Serialize
    {
        [Test]
        public void Person_NewSerializes()
        {
            DataContractSerializerSettings dcs_set = new DataContractSerializerSettings();
            dcs_set.PreserveObjectReferences = true;
            DataContractSerializer dcs =
                new DataContractSerializer(typeof(Person), dcs_set);

            Person init = new Person();

            MemoryStream cache = new MemoryStream();
            dcs.WriteObject(cache, init);
            cache.Seek(0, SeekOrigin.Begin);

            Person final = dcs.ReadObject(cache) as Person;

            Assert.That(
                init,
                Is.EqualTo(final).Using(new PersonComparer()),
                "Person did not round-trip.");
        }
        [Test]
        public void Person_Serializes()
        {
            DataContractSerializerSettings dcs_set = new DataContractSerializerSettings();
            dcs_set.PreserveObjectReferences = true;
            DataContractSerializer dcs =
                new DataContractSerializer(typeof(Person), dcs_set);

            Person init = new Person();
            init.FirstName = "George";
            init.LastName = "Monkey";
            init.Nickname = "Curious";
            init.Context = HypnosisRising.CaseWork.Common.Environment.Family;
            init.Role = "Pet";

            MemoryStream cache = new MemoryStream();
            dcs.WriteObject(cache, init);
            cache.Seek(0, SeekOrigin.Begin);

            Person final = dcs.ReadObject(cache) as Person;

            Assert.That(
                init,
                Is.EqualTo(final).Using(new PersonComparer()),
                "Person did not round-trip.");
        }

        [Test]
        public void Contact_NewSerializes()
        {
            DataContractSerializerSettings dcs_set = new DataContractSerializerSettings();
            dcs_set.PreserveObjectReferences = true;
            DataContractSerializer dcs =
                new DataContractSerializer(typeof(Contact), dcs_set);

            Contact init = new Contact();

            MemoryStream cache = new MemoryStream();
            dcs.WriteObject(cache, init);
            cache.Seek(0, SeekOrigin.Begin);

            Person final = dcs.ReadObject(cache) as Contact;

            Assert.That(
                init,
                Is.EqualTo(final).Using(new ContactComparer()),
                "Contact did not round-trip.");
        }
        [Test]
        public void Contact_Serializes()
        {
            DataContractSerializerSettings dcs_set = new DataContractSerializerSettings();
            dcs_set.PreserveObjectReferences = true;
            DataContractSerializer dcs =
                new DataContractSerializer(typeof(Contact), dcs_set);

            Contact init = new Contact();
            init.FirstName = "George";
            init.LastName = "Monkey";
            init.Nickname = "Curious";
            init.Context = HypnosisRising.CaseWork.Common.Environment.Family;
            init.Role = "Pet";
            init.EMail = "georgemonkey@jungle.org";
            init.Phone = "01-67-728396";
            init.HasText = false;

            MemoryStream cache = new MemoryStream();
            dcs.WriteObject(cache, init);
            cache.Seek(0, SeekOrigin.Begin);

            Contact final = dcs.ReadObject(cache) as Contact;

            Assert.That(
                init,
                Is.EqualTo(final).Using(new ContactComparer()),
                "Contact did not round-trip.");
        }

        [Test]
        public void Client_NewSerializes()
        {
            DataContractSerializerSettings dcs_set = new DataContractSerializerSettings();
            dcs_set.PreserveObjectReferences = true;
            DataContractSerializer dcs =
                new DataContractSerializer(typeof(Client), dcs_set);

            Client init = new Client();

            MemoryStream cache = new MemoryStream();
            dcs.WriteObject(cache, init);
            cache.Seek(0, SeekOrigin.Begin);

            Client final = dcs.ReadObject(cache) as Client;

            Assert.That(
                init,
                Is.EqualTo(final).Using(new ContactComparer()),
                "Client did not round-trip.");
        }
        [Test]
        public void Client_Serializes()
        {
            DataContractSerializerSettings dcs_set = new DataContractSerializerSettings();
            dcs_set.PreserveObjectReferences = true;
            DataContractSerializer dcs =
                new DataContractSerializer(typeof(Client), dcs_set);

            Client init = new Client();
            init.FirstName = "George";
            init.LastName = "Monkey";
            init.Nickname = "Curious";
            init.Context = HypnosisRising.CaseWork.Common.Environment.Family;
            init.Role = "Pet";
            init.EMail = "georgemonkey@jungle.org";
            init.Phone = "01-67-728396";
            init.HasText = false;
            init.DateOfBirth = DateTime.Parse("Aug 23, 1943");
            init.BillingRate = 150;

            Location addr = new Location();
            addr.Street1 = "4 Main Street";
            addr.Street2 = "Big Hickory";
            addr.District = "New York";
            addr.Region = "NY";
            addr.Country = "United States";
            addr.MailCode = "09421";
            init.HomeAddress = addr;

            Contact sister = new Contact();
            sister.FirstName = "Mimi";
            sister.LastName = "Monkey";
            init.Context = HypnosisRising.CaseWork.Common.Environment.Family;
            init.Role = "Sister";
            init.EMail = "mimimonkey@jungle.org";
            sister.Phone = "01-67-728396";
            sister.HasText = false;

            init.Partner = sister;

            Contact owner = new Contact();
            sister.FirstName = "Man";
            sister.LastName = "Yellow Hat";
            init.Context = HypnosisRising.CaseWork.Common.Environment.Family;
            init.Role = "Owner";
            init.EMail = "yellowhat@nyczoo.org";
            sister.Phone = "582-235-7238";
            sister.HasText = true;

            init.EmergencyContact = owner;

            MemoryStream cache = new MemoryStream();
            dcs.WriteObject(cache, init);
            cache.Seek(0, SeekOrigin.Begin);

            Person final = dcs.ReadObject(cache) as Client;

            Assert.That(
                init,
                Is.EqualTo(final).Using(new ClientComparer()),
                "Client did not round-trip.");
        }
    }
}
