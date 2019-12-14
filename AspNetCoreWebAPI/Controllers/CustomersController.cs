using System.Collections.Generic;
using AspNetCoreWebAPI.Models;
using AspNetCoreWebAPI.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerDao _dao;

        public CustomersController(ICustomerDao dao)
        {
            _dao = dao;
        }
        
        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customers = _dao.GetCustomers();
            return customers;
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "GetCustomerByID")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
