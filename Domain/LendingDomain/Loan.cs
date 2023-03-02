using System;

namespace LendingApp.LendingDomain
{
    public class Loan : IIdentifiable
    {
        public int Identifier { get; private set; }
        public decimal Amount { get; private set; }
        public Asset Asset { get; private set; }
        public Applicant Applicant { get; private set; }

        public LoanState LoanState { get; set; }

        public decimal LTV
        {
            get
            {
                if (Asset == null || Asset.Value == 0m)
                {
                    return 0m;
                }
                return Amount / Asset.Value;
            }
        }

        public Loan(int identifier, decimal amount, Asset asset, Applicant applicant)
        {
            Identifier = identifier;
            Amount = amount;
            Asset = asset;
            Applicant = applicant;
            LoanState = LoanState.Unknown;
        }

        public Loan(int identifier, decimal amount, Asset asset, Applicant applicant, LoanState loanState) 
            : this(identifier, amount, asset, applicant)
        {
            LoanState = loanState;
        }
    }
}
