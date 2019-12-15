using AspNetCoreWebAPI.Models;
using AspNetCoreWebAPI.Models.DataAccess;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.DataAccess.QBatis
{
    public class CustomerDao : ICustomerDao
    {
        private readonly IGenericDataSource _dataSource;

        public CustomerDao(IGenericDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dataSource.QueryForList<Customer>("Customers.GetCustomers", null);
        }

        public Customer GetCustomerByID(string id)
        {
            return _dataSource.QueryForObject<Customer>("Customers.GetCustomerByID", id);
        }

        public void CreateCustomer(Customer customer)
        {
            _dataSource.Insert("Customers.CreateCustomer", customer);
        }

        public void UpdateCustomer(string id, Customer customer)
        {
            _dataSource.Update("Customers.UpdateCustomer", customer);
        }

        public void DeleteCustomer(string id)
        {
            _dataSource.Delete("Customers.DeleteCustomer", id);
        }
    }
}
