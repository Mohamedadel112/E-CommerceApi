using AutoMapper;
using Domain.Contracts;
using Domain.Entities.OrderEntity;
using Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using ServiciesApstraction;
using Shared.DTOs;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using product = Domain.Entities.Product;
namespace Servicies
{
    internal class PaymentService(IBasketRepo basketRepo, 
        IMapper mapper, 
        IConfiguration configuration
        ,IUnitOfWork unitOfWork) : IPaymentService
    {
        /* 1] SetUp Secret Key Of Stripe
         * 2] Get Basket 
         * 3] Basket.Items.Price 
         * 4] Get Delivery Method And Shipping Price
         * 5] Retreive Delivery Method and Assign Price Of Basket [Shipping Price ]  = Delivery Method. Shippingprice
         * 6] Total = Subtotal + Shipping Price
         * 7] create Or Update Payment With Stripe
         * 8] Save Changes
         * 9] Mapping and Return
         * 
        */
        public async Task<BasketDTO> CreateOrUpdatePaymentIntentAsync(string basketId)
        {
            StripeConfiguration.ApiKey = configuration.GetSection("Stripe")["SecretKey"];// step 1
            var basket = await basketRepo.GetBasketAsync(basketId) ?? throw new BasketNotFoundException(basketId); //step 2
            foreach (var item in basket.Items)
            {
                var Product = await unitOfWork.GetRepository<product, int>().GetByIdAsync(item.Id)
                    ?? throw new ProductNotFoundException(item.Id);
                item.Price = Product.Price;

            }
            if (!basket.DeliveryMethodId.HasValue) throw new Exception("No Delivery Method is Selected");


            var Deliverymethod = await unitOfWork.GetRepository<DeliveryMethods, int>().GetByIdAsync(basket.DeliveryMethodId.Value)
                ?? throw new DeliveryMethodsNotFound(basket.DeliveryMethodId.Value);
            basket.ShippingPrice = Deliverymethod.Price;

            var amount = (long)(basket.Items.Sum(i => i.Price * i.Quantity) + basket.ShippingPrice )* 100;

            var service = new PaymentIntentService();
            if (!string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var PaymentUpdate = new PaymentIntentUpdateOptions
                {
                    Amount = amount
                };

                await service.UpdateAsync(basket.PaymentIntentId, PaymentUpdate);
            }
            else
            {
                var CreationOPtions = new PaymentIntentCreateOptions()
                {
                    Amount = amount,
                    Currency = "USD",
                    PaymentMethodTypes = new List<string> { "card" },

                };
                var PaymentIntent = await service.CreateAsync(CreationOPtions);

                basket.PaymentIntentId = PaymentIntent.Id;
                basket.ClientSecret = PaymentIntent.ClientSecret;
            }


            await basketRepo.CreateBasketAsync(basket);
            return mapper.Map<BasketDTO>(basket);






        }
    }
}
