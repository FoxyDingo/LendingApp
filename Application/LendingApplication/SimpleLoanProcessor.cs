using LendingApp.LendingApplication.Contract;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using LendingApp.LendingDomain;
using System.Linq;

namespace LendingApp.LendingApplication
{
    /// <summary>
    /// Implementation of <see cref="ILoanProcessor"/> calculating metrics in a single-threaded fashion.
    /// </summary>
    public class SimpleLoanProcessor : ILoanProcessor
    {
        private IServiceCollection _services;

        public const decimal MinLoan = 100000m;
        public const decimal MaxLoan = 1.5E6M;

        public const decimal BigLoan = 1E6M;

        /// <summary>
        /// Rules for Big Loans following format { LTV, CreditScore }
        /// If the Loan's LTV is smaller than LTV, then the Applicant's CreditScore needs to be bigger than CreditScore
        /// </summary>
        public Dictionary<decimal, int> BigLoanRules = new Dictionary<decimal, int>()
        {
            { .6m, 950 }
        };

        /// <summary>
        /// Rules for Small Loans following format { LTV, CreditScore }
        /// If the Loan's LTV is smaller than LTV, then the Applicant's CreditScore needs to be bigger than CreditScore
        /// </summary>
        public Dictionary<decimal, int> SmallLoanRules = new Dictionary<decimal, int>()
        {
            { .6m, 750 },
            { .8m, 800 },
            { .9m, 900 }
        };

        public SimpleLoanProcessor(IServiceCollection services)
        {
            _services = services;
        }

        public LoanMetrics GetLoanMetrics()
        {
            var loanAggregator = _services.BuildServiceProvider().GetService<ILoanAggregator>();
            var loans = loanAggregator.GetLoans();

            var totalApplicants = InitApplicants();
            var totalValue = 0m;
            var sumLTV = 0m;
            var countLTV = 0;

            foreach(var loan in loans)
            {
                totalApplicants[loan.LoanState]++;
                totalValue += loan.Amount;
                sumLTV += loan.LTV;
                countLTV++;
            }

            return new LoanMetrics(totalApplicants, totalValue, sumLTV / (decimal)countLTV);
        }

        public LoanState ProcessLoan(Loan loan)
        {
            if(loan.Amount > MaxLoan || loan.Amount < MinLoan)
            {
                return LoanState.Rejected;
            }

            if(loan.Amount >= BigLoan)
            {
                return ProcessLoan(BigLoanRules, loan);
            }

            return ProcessLoan(SmallLoanRules, loan);
        }

        /// <summary>
        /// Go through each rule boundary in ascending order
        /// Once a rule boundary's LTV matches, apply that rule following the rule's Credit Score
        /// </summary>
        /// <param name="loanRules"></param>
        /// <param name="loan"></param>
        /// <returns></returns>
        private LoanState ProcessLoan(Dictionary<decimal, int> loanRules, Loan loan)
        {
            var ruleBoundaries = loanRules.Keys.OrderBy(ltv => ltv).ToList();
            
            foreach(var ruleBoundary in ruleBoundaries)
            {
                if(loan.LTV < ruleBoundary)
                {
                    if(loan.Applicant.CreditScore >= loanRules[ruleBoundary])
                    {
                        return LoanState.Approved;
                    } 
                    else
                    {
                        return LoanState.Rejected;
                    }
                }
            }

            //Couldn't find a matching rule? -> Reject
            return LoanState.Rejected;
        }

        private Dictionary<LoanState, int> InitApplicants()
        {
            return new Dictionary<LoanState, int>() 
            {
                { LoanState.Unknown, 0 },
                { LoanState.Approved, 0 },
                { LoanState.Rejected, 0 }
            };
        }
    }
}
