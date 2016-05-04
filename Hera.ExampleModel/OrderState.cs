using Hera.DomainModeling.AggregareRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hera.DomainModeling.Identity;
using Hera.ExampleModel.Events;
using System.Runtime.Serialization;

namespace Hera.ExampleModel
{
    [Serializable]
    public class OrderState : AggregateRootState<OrderId>
    {
        public OrderState()
        {
            Items = new List<OrderItem>();
        }
        public OrderState(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            CustomerId = (CustomerId)info.GetValue("CustomerId", typeof(CustomerId));
            CreationDate = (DateTime)info.GetValue("CreationDate", typeof(DateTime));
            Status = (OrderStatus)info.GetValue("Status", typeof(OrderStatus));
            Items = (List<OrderItem>)info.GetValue("Items", typeof(List<OrderItem>));
        }

        public CustomerId CustomerId { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; }

        public void When(OrderCreated @event)
        {
            Id = @event.Id;
            CustomerId = @event.CustomerId;
            CreationDate = @event.CreationDate;
            Status = OrderStatus.Created;
        }
        public void When(MarkAsPaid @event)
        {
            Status = OrderStatus.Paid;
        }
        public void When(ReadyForDelivery @event)
        {
            Status = OrderStatus.ReadyForDelivery;
        }
        public void When(OrderDelivered @event)
        {
            Status = OrderStatus.Delivered;
        }
        public void When(ProductAdded @event)
        {
            var orderItem = new OrderItem((Order)Root, @event.OrderItemId, @event.ProductId, @event.Price, @event.Count);

            Items.Add(orderItem);
        }

        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("CustomerId", CustomerId, typeof(CustomerId));
            info.AddValue("CreationDate", CreationDate, typeof(DateTime));
            info.AddValue("Status", Status, typeof(OrderStatus));
            info.AddValue("Items", Items, typeof(List<OrderItem>));
        }
    }

    [Serializable]
    public class OrderId : GuidIdentity
    {
        public static OrderId NewId = new OrderId(Guid.NewGuid());

        public OrderId(Guid id) : base(id) { }
        public OrderId(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public enum OrderStatus
    {
        Created,
        Paid,
        ReadyForDelivery,
        Delivered
    }
}
