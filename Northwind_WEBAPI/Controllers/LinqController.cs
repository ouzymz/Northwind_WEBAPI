using Microsoft.AspNetCore.Authorization;
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
        public LinqController(NorthwindContext db, IConfiguration config)
        {
            _db = db;

        }


        [HttpGet]
        [Route("GetCustomerList")]
        [Authorize(Roles ="Admin,User")]
        public IActionResult GetAllStudents()
        {
            return Ok(_db.Customers.ToList());
        }

        [HttpGet]
        [Route("CustomerOrders")]
        [Authorize]

        public IActionResult CustomerOrders(string id)
        {
            var customerOders = _db.Orders.Where(x => x.CustomerId == id).ToList();
            return Ok(customerOders);
        }

        [HttpGet]
        [Route("OrderDetails")]
        [Authorize]
        public IActionResult OrderDetails(int Id)
        {
            var OrderDetail = _db.OrderDetails.Where(x => x.OrderId==Id).ToList();

            return Ok(OrderDetail);
        }

    }
}
