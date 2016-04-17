using Hera.DomainModeling;
using Hera.DomainModeling.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.ExampleModel.Events
{
    public class ProductAdded : IDomainEvent
    {
        public ProductAdded(OrderItemId orderItemId, ProductId productId, Price price, int count)
        {
            OrderItemId = orderItemId;
            ProductId = productId;
            Price = price;
            Count = count;
        }

        public OrderItemId OrderItemId { get; private set; }
        public ProductId ProductId { get; private set; }
        public Price Price { get; private set; }
        public int Count { get; private set; }
    }
}
