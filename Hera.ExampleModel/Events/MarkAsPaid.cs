using Hera.DomainModeling;
using Hera.DomainModeling.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.ExampleModel.Events
{
    public class MarkAsPaid : IDomainEvent
    {
        public MarkAsPaid(CustomerId customerId, Price total)
        {
            CustomerId = customerId;
            Price = total;
        }

        public CustomerId CustomerId { get; private set; }
        public Price Price { get; private set; }
    }
}
