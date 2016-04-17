using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.ExampleModel.DomainServices
{
    public interface IGoldMemberValidator
    {
        bool Validate(Customer customer, Price total);
    }
}
