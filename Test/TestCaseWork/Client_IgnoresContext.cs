using HypnosisRising.CaseWork.Common;
using HypnosisRising.CaseWork.Roles;
using NUnit.Framework;

namespace TestCaseWork
{
    [TestFixture]
    class Client_IgnoresContext
    {
        [Test]
        public void Inits_Self()
        {
            Client client = new Client();

            Assert.AreEqual(
                client.Context, Environment.Self,
                "Client does not initialize to Self.");
        }

        [Test]
        public void Ignores_ContextSet()
        {
            Client client = new Client();
            client.Context = Environment.Nature;

            Assert.AreEqual(
                client.Context, Environment.Self,
                "Client does not initialize to Self.");
        }
    }
}
