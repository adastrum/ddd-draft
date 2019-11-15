using Xxx.Domain.Common;

namespace Xxx.Domain.Aggregates.Foo
{
    public class Foo : Entity, IAggregateRoot
    {
        protected Foo()
        {

        }

        public Foo(FullName name)
        {
            Name = name;
        }

        public FullName Name { get; private set; }
    }
}
