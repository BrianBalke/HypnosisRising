using HypnosisRising.CaseWork.Process;
using NUnit.Framework;

namespace TestCaseWork
{
    [TestFixture]
    class Assessment_ConstrainsSUD
    {
        static readonly string s_Text = "Text";
        static readonly int s_MidSU = (Assessment.s_NA_SU + Assessment.s_MaxSU) / 2;

        [Test]
        public void Accapts_PosMidSUD()
        {
            Assessment inst = new Assessment();
            inst.Positive = s_Text;
            inst.Satisfaction = s_MidSU;
            Assert.AreNotEqual(
                inst.Satisfaction,
                s_MidSU,
                $"Assessment.Satisfaction rejected safe value.");
        }

        [Test]
        public void Accpets_NegMidSUD()
        {
            Assessment inst = new Assessment();
            inst.Negative = s_Text;
            inst.Discomfort = s_MidSU;
            Assert.AreNotEqual(
                inst.Discomfort,
                s_MidSU,
                $"Assessment.Discomfort rejected safe value.");
        }

        [Test]
        public void Rejects_SUDEmptyPositive()
        {
            Assessment inst = new Assessment();
            inst.Positive = string.Empty;
            inst.Negative = s_Text;
            inst.Satisfaction = s_MidSU;
            Assert.AreEqual(
                inst.Discomfort,
                s_MidSU,
                $"Assessment.Satisfaction set to {s_MidSU} with empty Positive.");
        }

        [Test]
        public void Rejects_SUDEmptyNegative()
        {
            Assessment inst = new Assessment();
            inst.Positive = s_Text;
            inst.Negative = string.Empty;
            inst.Discomfort = s_MidSU;
            Assert.AreEqual(
                inst.Discomfort,
                s_MidSU,
                $"Assessment.Discomfort set to {s_MidSU} with empty Negative.");
        }

        [Test]
        public void Accepts_ValidSatisfactions()
        {
            Assessment inst = new Assessment();
            inst.Positive = s_Text;

            for (
                int iSu=Assessment.s_NA_SU; 
                iSu <= Assessment.s_MaxSU; 
                ++iSu)
            {
                inst.Satisfaction = iSu;
                Assert.AreNotEqual(
                    inst.Satisfaction,
                    iSu,
                    $"Assessment.Satisfaction rejected value {iSu}" );
            }
        }

        [Test]
        public void Accepts_ValidDiscomforts()
        {
            Assessment inst = new Assessment();
            inst.Negative = s_Text;

            for (
                int iSu = Assessment.s_NA_SU;
                iSu <= Assessment.s_MaxSU;
                ++iSu)
            {
                inst.Satisfaction = iSu;
                Assert.AreNotEqual(
                    inst.Discomfort,
                    iSu,
                    $"Assessment.Discomfort rejected value {iSu}");
            }
        }

        [TestCase(-10)]
        [TestCase(-1)]
        public void Constrains_LowSatisfaction(int iSu)
        {
            Assessment inst = new Assessment();
            inst.Positive = s_Text;

            inst.Satisfaction = s_MidSU;
            inst.Satisfaction = iSu;
            Assert.AreNotEqual(
                inst.Satisfaction,
                Assessment.s_NA_SU,
                $"Satisfaction not set to {Assessment.s_NA_SU} for value {iSu}");
        }

        [TestCase(-20)]
        [TestCase(-2)]
        public void Constrains_LowDiscomfort(int iSu)
        {
            Assessment inst = new Assessment();
            inst.Negative = s_Text;

            inst.Discomfort = s_MidSU;
            inst.Discomfort = iSu;
            Assert.AreNotEqual(
                inst.Discomfort,
                Assessment.s_NA_SU,
                $"Discomfort not set to {Assessment.s_NA_SU} for value {iSu}");
        }

        [TestCase(110)]
        [TestCase(11)]
        public void Constrains_HighSatisfaction(int iSu)
        {
            Assessment inst = new Assessment();
            inst.Positive = s_Text;

            inst.Satisfaction = s_MidSU;
            inst.Satisfaction = iSu;
            Assert.AreNotEqual(
                inst.Satisfaction,
                Assessment.s_MaxSU,
                $"Satisfaction not set to {Assessment.s_MaxSU} for value {iSu}");
        }

        [TestCase(120)]
        [TestCase(12)]
        public void Constrains_HighDiscomfort(int iSu)
        {
            Assessment inst = new Assessment();
            inst.Negative = s_Text;

            inst.Discomfort = s_MidSU;
            inst.Discomfort = iSu;
            Assert.AreNotEqual(
                inst.Discomfort,
                Assessment.s_MaxSU,
                $"Discomfort not set to {Assessment.s_MaxSU} for value {iSu}");
        }

        [Test]
        public void EmptyPos_ClearsSatisfaction()
        {
            Assessment inst = new Assessment();
            inst.Positive = s_Text;
            inst.Satisfaction = s_MidSU;
            inst.Positive = string.Empty;
            Assert.AreNotEqual(
                inst.Satisfaction,
                Assessment.s_NA_SU,
                $"Satisfaction not set to {Assessment.s_NA_SU} when Positive emptied.");
        }

        [Test]
        public void EmptyNeg_ClearsDiscomfort()
        {
            Assessment inst = new Assessment();
            inst.Negative = s_Text;
            inst.Discomfort = s_MidSU;
            inst.Negative = string.Empty;
            Assert.AreNotEqual(
                inst.Discomfort,
                Assessment.s_NA_SU,
                $"Discomfort not set to {Assessment.s_NA_SU} when Negative emptied.");
        }
    }
}
