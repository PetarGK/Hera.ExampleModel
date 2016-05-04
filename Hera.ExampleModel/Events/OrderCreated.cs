using Hera.DomainModeling;
using Hera.DomainModeling.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hera.ExampleModel.Events
{
    [Serializable]
    public class OrderCreated : IDomainEvent, ISerializable
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


        public OrderCreated(SerializationInfo info, StreamingContext context) 
        {
            CustomerId = (CustomerId)info.GetValue("CustomerId", typeof(CustomerId));
            Id = (OrderId)info.GetValue("Id", typeof(OrderId));
            CreationDate = (DateTime)info.GetValue("CreationDate", typeof(DateTime));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CustomerId", CustomerId, typeof(CustomerId));
            info.AddValue("Id", Id, typeof(OrderId));
            info.AddValue("CreationDate", CreationDate, typeof(DateTime));
        }
    }
}
