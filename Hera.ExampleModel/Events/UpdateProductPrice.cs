using Hera.DomainModeling;
using Hera.DomainModeling.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.ExampleModel.Events
{
    public class UpdateProductPrice : IDomainEvent
    {
        public UpdateProductPrice(Price price)
        {
            Price = price;
        }

        public Price Price { get; private set; }
    }
}
