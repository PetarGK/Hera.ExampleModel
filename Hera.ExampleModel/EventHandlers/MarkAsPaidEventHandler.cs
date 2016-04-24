using Hera.ExampleModel.Events;
using Hera.DomainModeling.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hera.DomainModeling.Repository;
using Hera.ExampleModel.DomainServices;

namespace Hera.ExampleModel.EventHandlers
{
    public class MarkAsPaidEventHandler : IDomainEventHandler<MarkAsPaid>
    {
        private IAggregateRepository _repository;
        private IGoldMemberValidator _goldValidator;

        public MarkAsPaidEventHandler(IAggregateRepository repository, IGoldMemberValidator goldValidator)
        {
            _repository = repository;
            _goldValidator = goldValidator;
        }

        public void Handle(MarkAsPaid @event)
        {
            var customer = _repository.Load<Customer>(@event.CustomerId);

            if (_goldValidator.Validate(customer, @event.Price))
            {
                customer.MarkAsGoldMember();
                _repository.Save(customer);
            }
        }
    }
}
