using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hera.DomainModeling.AggregareRoot;

namespace Hera.ExampleModel
{
    public class Customer : AggregateRoot<CustomerState>
    {
        protected Customer() : base() { }

        public void MarkAsGoldMember()
        {
            // Validate

        }
    }
}
