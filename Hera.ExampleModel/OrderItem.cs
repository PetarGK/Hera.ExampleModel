using Hera.DomainModeling.Entity;
using Hera.ExampleModel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hera.ExampleModel
{
    public class OrderItem : Entity<OrderItemState>
    {
        public OrderItem(Order order, OrderItemId id, ProductId productId, Price price, int count) : base(order, id)
        {
            State.ProductId = productId;
            State.Price = price;
            State.Count = count;
        }
        public OrderItem(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

        public ProductId ProductId
        {
            get { return State.ProductId; }
        }
        public decimal Total
        {
            get { return 20m; /* State.Price * State.Count */ }
        }

        public void UpdatePrice(Price price)
        {
            // Validate logic

            Apply(new UpdateProductPrice(price));
        }
    }
}
