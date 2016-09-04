using CustomerODataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;

namespace CustomerODataService.Controllers
{
    public class CustomersController : ODataController
    {
        CustomerDataContext ctx = new CustomerDataContext();

        [EnableQuery]
       public IQueryable<Customer> Get()
        {
            return ctx.Customers.AsQueryable();
        }

        [EnableQuery]
        public SingleResult<Customer> Get([FromODataUri] int key)
        {
            IQueryable<Customer> result = ctx.Customers
                .Where(c => c.CustomerID == key);

            return SingleResult.Create(result);
        }
        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
            base.Dispose(disposing);
        }
    }
}