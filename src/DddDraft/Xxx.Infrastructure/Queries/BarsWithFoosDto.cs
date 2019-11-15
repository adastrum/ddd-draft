using System;
using System.Collections.Generic;

namespace Xxx.Infrastructure.Queries
{
    public class BarDto
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public List<BazDto> Bazs { get; set; }
    }
}
