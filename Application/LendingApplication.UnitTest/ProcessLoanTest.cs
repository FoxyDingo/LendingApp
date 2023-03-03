using LendingApp.LendingDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LendingApp.LendingApplication.UnitTest
{
    [TestClass]
    public class ProcessLoanTest
    {   
        [TestMethod]
        public void ProcessLoan_BigLoan_Success()
        {
            //TODO: it isn't great having to pass a null parameter since the method
            //under test doesn't have any dependencies - the method should be moved
            //to a pure functions project
            var loanProcessor = new SimpleLoanProcessor(null);

            //ARRANGE
            //LTV 60% - Credit Score 950
            var loan = new Loan(1, 1E6M, new Asset(1, 1.67E6M), new Applicant(1, 950));

            //ACT
            var state = loanProcessor.ProcessLoan(loan);

            //ASSERT
            Assert.AreEqual(LoanState.Approved, state);
        }

        [TestMethod]
        public void ProcessLoan_BigLoan_FailureDueToLTV()
        {
            var loanProcessor = new SimpleLoanProcessor(null);

            //ARRANGE
            //LTV 60.6% - Credit Score 950
            var loan = new Loan(1, 1E6M, new Asset(1, 1.65E6M), new Applicant(1, 950));

            //ACT
            var state = loanProcessor.ProcessLoan(loan);

            //ASSERT
            Assert.AreEqual(LoanState.Rejected, state);
        }

        [TestMethod]
        public void ProcessLoan_BigLoan_FailureDueToCreditScore()
        {
            var loanProcessor = new SimpleLoanProcessor(null);

            //ARRANGE
            //LTV 60% - Credit Score 949
            var loan = new Loan(1, 1E6M, new Asset(1, 1.67E6M), new Applicant(1, 949));

            //ACT
            var state = loanProcessor.ProcessLoan(loan);

            //ASSERT
            Assert.AreEqual(LoanState.Rejected, state);
        }

        //TODO
        //Add tests for Small Loans

        //TODO
        //Add tests for Min / Max loan values
    }
}
