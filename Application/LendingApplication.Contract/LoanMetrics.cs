using LendingApp.LendingDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LendingApp.LendingApplication.Contract
{
    public class LoanMetrics
    {
        public IDictionary<LoanState, int> TotalApplicants { get; private set; }

        public decimal TotalValue { get; private set; }

        public decimal MeanLTV { get; private set; }

        public LoanMetrics(IDictionary<LoanState, int> totalApplicants, decimal totalValue, decimal meanLtv)
        {
            TotalApplicants = totalApplicants;
            TotalValue = totalValue;
            MeanLTV = meanLtv;
        }
    }
}
