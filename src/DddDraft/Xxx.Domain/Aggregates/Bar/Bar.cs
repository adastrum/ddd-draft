using System;
using System.Collections.Generic;
using System.Linq;
using Xxx.Domain.Common;

namespace Xxx.Domain.Aggregates.Bar
{
    public class Bar : Entity, IAggregateRoot
    {
        private readonly List<Baz> _bazs = new List<Baz>();
        private int? _fooId;

        public Bar()
        {
            Created = DateTime.UtcNow;
        }

        public IReadOnlyCollection<Baz> Bazs => _bazs.AsReadOnly();

        public DateTime Created { get; private set; }

        public void AddBaz(string code, string description)
        {
            var existingBaz = _bazs.SingleOrDefault(x => x.Code == code);
            if (existingBaz == null)
            {
                var baz = new Baz(code, description);
                _bazs.Add(baz);
            }
            else
            {
                existingBaz.SetQuantity(existingBaz.Quantity + 1);
            }
        }

        public int? GetFooId => _fooId;

        public void SetFooId(int fooId)
        {
            _fooId = fooId;
        }
    }
}
