using Hera.DomainModeling.Entity;
using Hera.DomainModeling.Identity;
using Hera.DomainModeling.ValueObject;
using Hera.ExampleModel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hera.ExampleModel
{
    [Serializable]
    public class OrderItemState : EntityState<OrderItemId>
    {
        public ProductId ProductId { get; set; }
        public Price Price { get; set; }
        public int Count { get; set; }

        public void When(UpdateProductPrice @event)
        {
            Price = @event.Price;
        }

        public OrderItemState() { }
        public OrderItemState(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            ProductId = (ProductId)info.GetValue("ProductId", typeof(ProductId));
            Price = (Price)info.GetValue("Price", typeof(Price));
            Count = info.GetInt32("Count");
        }

        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("ProductId", ProductId, typeof(ProductId));
            info.AddValue("Price", Price, typeof(Price));
            info.AddValue("Count", Count);
        }
    }

    [Serializable]
    public class OrderItemId : GuidIdentity
    {
        public OrderItemId(Guid id) : base(id) { }
        public OrderItemId(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class ProductId : GuidIdentity
    {
        public ProductId(Guid id) : base(id) { }
        public ProductId(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class Price : ValueObject<Price>, ISerializable
    {
        private decimal _value;

        public Price(decimal value)
        {
            // Validate invariants

            _value = value;
        }

        public Price(SerializationInfo info, StreamingContext context)
        {
            _value = (decimal)info.GetValue("_value", typeof(decimal));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_value", _value, typeof(decimal));
        }
    }
}
