using Hera.DomainModeling;
using Hera.DomainModeling.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.ExampleModel.Events
{
    public class OrderCreated : IDomainEvent
    {
        public OrderCreated(CustomerId customerId, OrderId id, DateTime creationDate)
        {
            CustomerId = customerId;
            Id = id;
            CreationDate = creationDate;
        }

        public CustomerId CustomerId { get; private set; }
        public OrderId Id { get; private set; }
        public DateTime CreationDate { get; private set; }
    }
}
