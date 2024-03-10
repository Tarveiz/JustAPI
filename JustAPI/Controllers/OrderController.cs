using JustAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

namespace JustAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private static List<Order> actualOrders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    ProductList = new List<Product>()
                    {
                        new Product() {  Id = 1, Name = "Картофель", Description = "Прекрасный картофель"},
                        new Product() { Id = 2, Name = "Стиральная машина"},
                        new Product() {Id = 3}
                    },
                    OrderDate = new DateTime(2023, 11, 29, 18, 45, 0, DateTimeKind.Utc),
                    DeliveryType = Enums.DeliveryType.PostOffice,
                    OrderCost = 1000,
                    Currency = Enums.Currency.Rubble
                },
                new Order
                {
                    Id = 2,
                    ProductList = new List<Product>()
                    {
                        new Product() {  Id = 1, Name = "Лук", Description = "Прекрасный лук"},
                        new Product() { Id = 2, Name = "Посудомоечная машина"},
                        new Product() {Id = 3}
                    },
                    OrderDate = new DateTime(2023, 5, 11, 1, 12, 53, DateTimeKind.Local),
                    DeliveryType = Enums.DeliveryType.PickUp,
                    OrderCost = 750,
                    Currency = Enums.Currency.Dollar
                }
            };

        [HttpGet("GetAllOrders")]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            return Ok(actualOrders);
        }

        [HttpGet("GetOrder{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = actualOrders.Find(x => x.Id == id);
            if (order is null)
                return NotFound("Order not found");
            return Ok(order);
        }

        [HttpPost("CreateOrder")]
        public async Task<ActionResult<List<Order>>> CreateOrder(Order order)
        {
            actualOrders.Add(order);
            return Ok(actualOrders);
        }
    }
}
