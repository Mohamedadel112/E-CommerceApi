using Microsoft.AspNetCore.Mvc;
using ServiciesApstraction;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class OrderController(IServicesManager servicesManager): ApiController
    {
        [HttpPost]
        public async Task<ActionResult<OrderResultDTO>>Create(OrderRequestDTO request)
        {
            var email = User.FindFirst(ClaimTypes.Email);
            var order = await servicesManager.OrderServices.CreateOrderAsync(request, email.ToString());
            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResultDTO>>> GetAllOrderByEmail()
        {
            var email = User.FindFirst(ClaimTypes.Email);
            var orders = await servicesManager.OrderServices.GetAllOrderByEmailAsync(email.ToString());
            return Ok(orders);

        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<OrderResultDTO>> GetAllOrderById(Guid Id)
        {
            var order = await servicesManager.OrderServices.GetOrderByIDAsync(Id);
            return Ok(order);

        }

        [HttpGet("Delivery Method")]
        public async Task<ActionResult<IEnumerable<DeliveryMethodRequestDTO>>> GetAllDeliveryMethod()
        {
            return Ok(await servicesManager.OrderServices.GetDeliveryAsync());
        }





















    }
}
