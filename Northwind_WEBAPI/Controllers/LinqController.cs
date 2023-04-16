using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind_WEBAPI.Models;

namespace Northwind_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqController : ControllerBase
    {
        NorthwindContext _db;
        public LinqController(NorthwindContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("GetCustomerList")]
        public IActionResult GetAllStudents()
        {
            return Ok(_db.Customers.ToList());
        }

        [HttpGet]
        [Route("CustomerOrders")]
        public IActionResult CustomerOrders(string id)
        {
            var customerOders = _db.Orders.Where(x => x.CustomerId == id).ToList();
            return Ok(customerOders);
        }

        [HttpGet]
        [Route("OrderDetails")]
        public IActionResult OrderDetails(int Id)
        {
            var OrderDetail = _db.OrderDetails.Where(x => x.OrderId==Id).ToList();

            return Ok(OrderDetail);
        }

    }
}
