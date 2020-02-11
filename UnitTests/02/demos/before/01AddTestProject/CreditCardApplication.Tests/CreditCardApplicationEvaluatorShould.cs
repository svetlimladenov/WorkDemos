using System;
using CreditCardApplications;
using Moq;
using Xunit;

namespace CreditCardApplication.Tests
{
    public class CreditCardApplicationEvaluatorShould
    {
        [Fact]
        public void AcceptHighIncomeApplications()
        {
            var mockValidator = new Mock<IFrequentFlyerNumberValidator>();

            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);

            var application = new CreditCardApplications.CreditCardApplication()
            {
                GrossAnnualIncome = 100_000
            };

            var decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.AutoAccepted, decision);
        }

        [Fact]
        public void ReferYoungApplications()
        {
            var mockValidator = new Mock<IFrequentFlyerNumberValidator>();
            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);

            var application = new CreditCardApplications.CreditCardApplication()
            {
                Age = 19
            };

            var decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman, decision);
        }


        [Fact]
        public void DeclineLowIncomeApplications()
        {
            var mockValidator = new Mock<IFrequentFlyerNumberValidator>();

            //ako e "x" shte vurne true inache - false
            //mockValidator.Setup(x => x.IsValid("x")).Returns(true);

            //ako ne ni puka kakvo se podava na metoda slagame isAny
            mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);

            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);

            var application = new CreditCardApplications.CreditCardApplication()
            {
                Age = 42,
                GrossAnnualIncome = 19999
            };

            var decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.AutoDeclined, decision);
        }

    }
}
