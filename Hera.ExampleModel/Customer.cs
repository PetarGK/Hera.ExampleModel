using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hera.DomainModeling.AggregareRoot;
using System.Runtime.Serialization;

namespace Hera.ExampleModel
{
    public class Customer : AggregateRoot<CustomerState>
    {
        public void MarkAsGoldMember()
        {
            // Validate

        }
    }
}
