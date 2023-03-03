using System;
using System.Collections.Generic;
using LendingApp.LendingDomain;

namespace LendingApp.LendingApplication.Contract
{
    /// <summary>
    /// Interface to support the persistence of Loans (and associated domain)
    /// </summary>
    public interface ILoanAggregator
    {
        /// <summary>
        /// Get all Loans in the system
        /// </summary>
        /// <returns>List of all loans currently saved to the system</returns>
        public IList<Loan> GetLoans();

        /// <summary>
        /// Get all Loans in the system that match a certain LoanState
        /// </summary>
        /// <returns>List of all loans currently saved to the system</returns>
        public IList<Loan> GetLoans(LoanState loanState);

        /// <summary>
        /// Add Loan to the system
        /// </summary>
        /// <param name="loan">The loan to add</param>
        /// <returns>Success state</returns>
        public bool AddLoan(Loan loan);

        /// <summary>
        /// Update state of a loan
        /// </summary>
        /// <param name="loanId">Identifier for the loan</param>
        /// <param name="loanState"></param>
        /// <returns>Success state</returns>
        public bool UpdateState(int loanId, LoanState loanState);
    }
}
