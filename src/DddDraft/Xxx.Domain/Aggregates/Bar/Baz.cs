using System;
using Xxx.Domain.Common;
using Xxx.Domain.Exceptions;

namespace Xxx.Domain.Aggregates.Bar
{
    public class Baz : Entity
    {
        protected Baz()
        {

        }

        public Baz(string code, string description)
        {
            Code = code;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Quantity = 1;
        }

        public string Code { get; private set; }

        public string Description { get; private set; }

        public int Quantity { get; private set; }

        public void SetQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new XxxDomainException("Negative quantity");
            }

            Quantity = quantity;
        }
    }
}
