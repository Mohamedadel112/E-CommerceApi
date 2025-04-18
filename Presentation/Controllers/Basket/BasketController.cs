using Microsoft.AspNetCore.Mvc;
using ServiciesApstraction;
using Shared.DTOs;


namespace Presentation.Controllers.Basket
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController(IServicesManager servicesManager) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<BasketDTO>> GetBasket(string id)
        {
          var basket= await  servicesManager.BasketServices.GetBasketAsync(id);
            return Ok(basket);

        }



        [HttpPost]
        public async Task<ActionResult<BasketDTO>> CreateBasket(BasketDTO basket)
        {
            var basketcreated = await servicesManager.BasketServices.CreateBasketAsync(basket);
            return Ok(basketcreated);
        }




        [HttpDelete]
        public async Task<ActionResult> DeleteBasket(string id)
        {
            await servicesManager.BasketServices.DeleteBasketAsync(id);
            return NoContent();
        }








    }
}
