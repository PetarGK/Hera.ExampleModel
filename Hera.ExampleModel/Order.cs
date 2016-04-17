using Hera.DomainModeling.AggregareRoot;
using Hera.ExampleModel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.ExampleModel
{
    public class Order : AggregateRoot<OrderState>
    {
        protected Order() : base() { }

        public Order(CustomerId customerId, OrderId id)
        {
            // Validation logic here

            Apply(new OrderCreated(customerId, id, DateTime.Now));
        }

        public void AddProduct(ProductId productId, Price price, int count)
        {
            // Validate logic

            Apply(new ProductAdded(new OrderItemId(Guid.NewGuid()), productId, price, count));
        }
        public void UpdateProductPrice(ProductId productId, Price price)
        {
            //Validate existing of the product

            State.Items.Single(s => s.ProductId == productId).UpdatePrice(price);
        }
        public void MarkAsPaid()
        {
            // Validation logic here
            if (State.Status != OrderStatus.Created)
                throw new ApplicationException("Invalid status");

            Apply(new MarkAsPaid(State.CustomerId, new Price(State.Items.Sum(s => s.Total))));
        }
        public void ReadyForDelivery()
        {
            // Validation logic here
            if (State.Status != OrderStatus.Paid)
                throw new ApplicationException("Invalid status");

            Apply(new ReadyForDelivery());
        }
        public void Delivered()
        {
            // Validation logic here
            if (State.Status != OrderStatus.ReadyForDelivery)
                throw new ApplicationException("Invalid status");

            Apply(new OrderDelivered());
        }
    }
}
