using System.Collections.Generic;

namespace AspNetCoreWebAPI.Models.DataAccess
{
    public interface ICustomerDao
    {
        IEnumerable<Customer> GetCustomers();
    }
}
