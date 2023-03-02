using System;

namespace LendingApp.LendingDomain
{
    public class Applicant : IIdentifiable
    {
        public int Identifier { get; private set; }
        public int CreditScore { get; set; }

        public Applicant(int identifier, int initialCreditScore)
        {
            Identifier = identifier;
            CreditScore = initialCreditScore;
        }
    }
}
