using System;
using System.Collections.Generic;
using LendingApp.LendingDomain;

namespace LendingApp.LendingApplication.Contract
{
    /// <summary>
    /// Interface to support processing data related to loans
    /// </summary>
    public interface ILoanProcessor
    {
        /// <summary>
        /// Gets metrics related to all loans added to date
        /// </summary>
        /// <param name="loan">The loan to add</param>
        /// <returns>Success state</returns>
        public LoanMetrics GetLoanMetrics();

        /// <summary>
        /// Process if loan application is approved or rejected
        /// 
        /// NOTE: Consider separating this method since it has no dependencies,
        /// perhaps it should be in a pure functions project
        /// </summary>
        /// <param name="loan"></param>
        /// <returns>LoanState after processing application</returns>
        public LoanState ProcessLoan(Loan loan);
    }
}
