using Hera.DomainModeling.AggregareRoot;
using Hera.DomainModeling.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.ExampleModel
{
    public class CustomerState : AggregateRootState<CustomerId>
    {
    }

    public class CustomerId : GuidIdentity
    {
        public CustomerId(Guid id) : base(id) { }
    }
}
