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
    public class ProductAdded : IDomainEvent, ISerializable
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


        public ProductAdded(SerializationInfo info, StreamingContext context)
        {
            OrderItemId = (OrderItemId)info.GetValue("OrderItemId", typeof(OrderItemId));
            ProductId = (ProductId)info.GetValue("ProductId", typeof(ProductId));
            Price = (Price)info.GetValue("Price", typeof(Price));
            Count = (int)info.GetValue("Count", typeof(int));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OrderItemId", OrderItemId, typeof(OrderItemId));
            info.AddValue("ProductId", ProductId, typeof(ProductId));
            info.AddValue("Price", Price, typeof(Price));
            info.AddValue("Count", Count, typeof(int));
        }
    }
}
