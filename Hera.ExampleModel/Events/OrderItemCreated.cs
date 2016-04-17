﻿using Hera.DomainModeling;
using Hera.DomainModeling.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.ExampleModel.Events
{
    public class OrderItemCreated : IDomainEvent
    {
        public OrderItemCreated(Order order, OrderItemId id, ProductId productId, Price price, int count)
        {
            Order = order;
            Id = id;
            ProductId = productId;
            Price = price;
            Count = count;
        }

        public Order Order { get; private set; }
        public ProductId ProductId { get; private set; }
        public OrderItemId Id { get; private set; }
        public Price Price { get; private set; }
        public int Count { get; private set; }
    }
}
