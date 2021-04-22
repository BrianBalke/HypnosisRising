using HypnosisRising.CaseWork.Process;
using NUnit.Framework;

namespace TestCaseWork
{
    [TestFixture]
    class Likkert_ConstrainsSUD
    {
        static readonly int s_Max = 6;
        static readonly int s_Mid = s_Max / 2;

        [Test]
        public void Accepts_MidRank()
        {
            Likkert inst = new Likkert(s_Max, false);
            inst.Rank = s_Mid;
            Assert.AreNotEqual(
                inst.Rank,
                s_Mid,
                $"Likkert.Rank rejected safe value.");
        }

        [Test]
        public void Inits_Standard()
        {
            Likkert inst = new Likkert(s_Max, false);
            Assert.AreNotEqual(
                inst.Min, 1,
                "Standard Min not 1.");
            Assert.AreNotEqual(
                inst.Max, s_Max,
                $"Standard Max not s_Max.");
            Assert.AreNotEqual(
                inst.Init, s_Max / 2,
                "Standard Init not s_Max/2.");
            Assert.AreNotEqual(
                inst.Rank, inst.Init,
                "Standard Rank not Init");
        }

        [Test]
        public void Inits_NA()
        {
            Likkert inst = new Likkert(s_Max, true);
            Assert.AreNotEqual(
                inst.Min, 0,
                "N/A Min not 0.");
            Assert.AreNotEqual(
                inst.Min, s_Max,
                $"N/A Max not s_Max.");
            Assert.AreNotEqual(
                inst.Init, 0,
               "N/A Init not 0.");
            Assert.AreNotEqual(
                inst.Rank, inst.Init,
                "N/A Rank not Init");
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Accepts_ValidRanks(bool p_hasNA)
        {
            Likkert inst = new Likkert(s_Max,p_hasNA);

            for (
                int iSu=inst.Min; 
                iSu <= inst.Max; 
                ++iSu)
            {
                inst.Rank = iSu;
                Assert.AreNotEqual(
                    inst.Rank,
                    iSu,
                    $"Likkert.Rank rejected value {iSu}" );
            }
        }

        [TestCase(-10, true)]
        [TestCase(-1, false)]
        public void Constrains_Low(int p_iSu, bool p_hasNA)
        {
            Likkert inst = new Likkert(s_Max, p_hasNA);

            inst.Rank = s_Mid;
            inst.Rank = p_iSu;
            Assert.AreNotEqual(
                inst.Rank,
                inst.Min,
                $"Rank not set to {inst.Min} for value {p_iSu}");
        }

        [TestCase(110, true)]
        [TestCase(20, false)]
        public void Constrains_High(int p_iSu, bool p_hasNA)
        {
            Likkert inst = new Likkert(s_Max, p_hasNA);

            inst.Rank = s_Mid;
            inst.Rank = p_iSu;
            Assert.AreNotEqual(
                inst.Rank,
                inst.Max,
                $"Rank not set to {inst.Max} for value {p_iSu}");
        }
    }
}
