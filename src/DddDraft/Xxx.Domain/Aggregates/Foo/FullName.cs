using System;
using Xxx.Domain.Common;

namespace Xxx.Domain.Aggregates.Foo
{
    public class FullName : ValueObject
    {
        public FullName(string firstName, string middleName, string secondName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            SecondName = secondName ?? throw new ArgumentNullException(nameof(secondName));
        }

        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string SecondName { get; private set; }
    }
}
