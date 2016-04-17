﻿using Hera.DomainModeling.Entity;
using Hera.ExampleModel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ProductId ProductId
        {
            get { return State.ProductId; }
        }

        public void UpdatePrice(Price price)
        {
            // Validate logic

            Apply(new UpdateProductPrice(price));
        }
    }
}