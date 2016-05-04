using Hera.DomainModeling.AggregareRoot;
using Hera.DomainModeling.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hera.ExampleModel
{
    [Serializable]
    public class CustomerState : AggregateRootState<CustomerId>
    {
        public CustomerState() { }
        public CustomerState(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }

    [Serializable]
    public class CustomerId : GuidIdentity
    {
        public CustomerId(Guid id) : base(id) { }
        public CustomerId(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
