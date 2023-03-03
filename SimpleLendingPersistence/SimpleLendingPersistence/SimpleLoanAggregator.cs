using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LendingApp.LendingApplication.Contract;
using LendingApp.LendingDomain;
using Microsoft.Extensions.Logging;

namespace LendingApp.SimpleLendingPersistence
{
    /// <summary>
    /// Implementation of <see cref="ILoanAggregator"/> keeping an in-memory list of loans.
    /// </summary>
    public class SimpleLoanAggregator : ILoanAggregator
    {
        private readonly ILogger _logger;
        public IList<Loan> Loans = new List<Loan>() {};

        public SimpleLoanAggregator(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SimpleLoanAggregator>();
        }

        public IList<Loan> GetLoans()
        {
            return Loans;
        }

        public bool AddLoan(Loan loan)
        {
            Loans.Add(loan);
            return true;
        }

        public bool UpdateState(int loanId, LoanState loanState)
        {
            var matchingLoans = Loans.Where(l => l.Identifier == loanId).ToList();
            if (!matchingLoans.Any())
            {
                _logger.LogError("No loan matching ID " + loanId);
                return false;
            }

            if (matchingLoans.Count() > 1)
            {
                _logger.LogError("Multiple loans matching ID " + loanId);
                return false;
            }

            var loan = matchingLoans[0];
            loan.LoanState = loanState;

            return true;
        }

        public IList<Loan> GetLoans(LoanState loanState)
        {
            return Loans.Where(loan => loan.LoanState == loanState).ToList();
        }
    }
}
