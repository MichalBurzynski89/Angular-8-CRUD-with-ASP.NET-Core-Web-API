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
    }
}
