using System.Collections.Generic;

namespace AspNetCoreWebAPI.Models.DataAccess
{
    public interface ICustomerDao
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerByID(string id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(string id, Customer customer);
        void DeleteCustomer(string id);
    }
}
