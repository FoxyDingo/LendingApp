using System;

namespace LendingApp.LendingDomain
{
    public class Asset : IIdentifiable
    {
        public int Identifier { get; private set; }
        public decimal Value { get; private set; }

        public Asset(int identifier, decimal value)
        {
            Identifier = identifier;
            Value = value;
        }
    }
}
