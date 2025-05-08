using Microsoft.AspNetCore.Mvc;
using ServiciesApstraction;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{

    
    public class PaymentController(IServicesManager servicesManager) : ApiController
    {
        [HttpPost("{basketId}")]
        public async Task<ActionResult<BasketDTO>>CreateOrUpdate(string basketId)
        {
            var result = await servicesManager.PaymentServices.CreateOrUpdatePaymentIntentAsync(basketId);
            return Ok(result);
        }

        public async Task<ActionResult> WebHock()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var StripeHeader = Request.Headers["Stripe-Signature"];
            await servicesManager.PaymentServices.UpdatePaymentStatus(json, StripeHeader);
            return new EmptyResult();
        }








    }
}
