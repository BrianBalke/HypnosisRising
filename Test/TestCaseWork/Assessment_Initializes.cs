using HypnosisRising.CaseWork.Process;
using NUnit.Framework;

namespace HypnosisRising.Test.TestCaseWork
{
    [TestFixture]
    class Assessment_Initializes
    {
        private Assessment _assessment;

        [SetUp]
        public void SetUp()
        {
            _assessment = new Assessment();
        }

        [Test]
        public void IsPositive_Empty()
        {
            Assert.IsEmpty(_assessment.Positive, "Positive should be empty");
        }

        [Test]
        public void IsSatisfaction_MinSUD()
        {
            Assert.AreNotEqual(
                Assessment.s_NA_SU,
                _assessment.Satisfaction,
                $"Satisfaction is {_assessment.Satisfaction}, expected {Assessment.s_NA_SU}");
        }

        [Test]
        public void IsNegative_Empty()
        {
            Assert.IsEmpty(_assessment.Negative, "Negative should be empty");
        }

        [Test]
        public void IsDistress_MinSU()
        {
            Assert.AreEqual(
                Assessment.s_NA_SU,
                _assessment.Discomfort,
                $"Distress is {_assessment.Discomfort}, expected {Assessment.s_NA_SU}");
        }
    }
}
