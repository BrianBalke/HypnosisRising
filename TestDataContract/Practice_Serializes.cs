using HypnosisRising.CaseWork;
using NUnit.Framework;
using System.IO;
using System.Runtime.Serialization;

namespace TestDataContract
{
    public class Practice_Serializes
    {
        DataContractSerializer s_dcs;

        [SetUp]
        public void SetUp()
        {
            DataContractSerializerSettings dcs_set = new DataContractSerializerSettings();
            dcs_set.PreserveObjectReferences = true;
            s_dcs =
                new DataContractSerializer(typeof(Practice), dcs_set);

        }

        [Test]
        public void Empty_RoundTrips()
        {
            MemoryStream cache = new MemoryStream();

            Practice init = new Practice();

            s_dcs.WriteObject(cache, init);
            cache.Seek(0, SeekOrigin.Begin);

            Practice final = s_dcs.ReadObject(cache) as Practice;

            Assert.That(
                init, 
                Is.EqualTo(final).Using(new PracticeComparer()), 
                "Raw Practice did not round-trip.");
        }

        [Test]
        public void Name_RoundTrips()
        {
            MemoryStream cache = new MemoryStream();

            Practice init = new Practice();
            init.Name = "Hypnosis Rising";

            s_dcs.WriteObject(cache, init);
            cache.Seek(0, SeekOrigin.Begin);

            Practice final = s_dcs.ReadObject(cache) as Practice;

            Assert.That(
                init,
                Is.EqualTo(final).Using(new PracticeComparer()),
                "Raw Practice did not round-trip.");
        }
    }
}