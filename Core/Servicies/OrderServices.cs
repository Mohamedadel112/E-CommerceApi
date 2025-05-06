using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.OrderEntity;
using Domain.Exceptions;
using Servicies.Specifications;
using ServiciesApstraction;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Address = Domain.Entities.OrderEntity.Address;

namespace Servicies
{
    internal class OrderServices(IMapper mapper,IBasketRepo basketRepo,IUnitOfWork unitOfWork) : IOrderServices
    {
        public async Task<OrderResultDTO> CreateOrderAsync(OrderRequestDTO request, string UserEmail)
        {
            // Get Address 
            var ShipingAddress = mapper.Map<Address>(request.shipToAddress);

            // OrderItems => Basket [Basket id] => BasketItem => orderItems

            var basket= await basketRepo.GetBasketAsync(request.BasketId) ?? throw new BasketNotFoundException(request.BasketId);
            var Orderitems = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(item.Id)
                    ?? throw new ProductNotFoundException(item.Id);
                Orderitems.Add(CreateOrderItem(item, product));

            }

            //Delivery Methods 

            var delivery = await unitOfWork.GetRepository<DeliveryMethods, int>().GetByIdAsync(request.DeliveryMethodId)
                ?? throw new DeliveryMethodsNotFound(request.DeliveryMethodId);

            // SubTotal

            var Subtotal = Orderitems.Sum(i => i.Price * i.Quantity);

            // Create Order

            Order order = new(UserEmail, ShipingAddress, Orderitems, delivery,Subtotal,basket.PaymentIntentId);
            var OrderRepo = unitOfWork.GetRepository<Order, Guid>();

            await OrderRepo.AddAsync(order);
            var ExistingOrder = await OrderRepo.GetByIdAsync(new OrderWithPaymentIntentIdSpecification(basket.PaymentIntentId));
            if(ExistingOrder != null)
            {
                OrderRepo.DeleteAsync(ExistingOrder);
            }
            await  unitOfWork.SaveChangesAsync();
            return mapper.Map<OrderResultDTO>(order);




        }

        private OrderItem CreateOrderItem(BasketItem item, Product product)
        {
            var productitem = new ProductInOrder(product.Id, product.Name, product.PictureUrl);
            return new OrderItem(productitem, item.Quantity, product.Price);
        }

        public async Task<IEnumerable<OrderResultDTO>> GetAllOrderByEmailAsync(string UserEmail)
        {
            var order = await unitOfWork.GetRepository<Order, Guid>().GetAllAsync(new OrderIncludeSpecification(UserEmail));
            return mapper.Map<IEnumerable<OrderResultDTO>>(order);
        }

        public async Task<IEnumerable<DeliveryMethodRequestDTO>> GetDeliveryAsync()
        {
            var Method = await unitOfWork.GetRepository<DeliveryMethods, int>().GetAllAsync();
            return mapper.Map<IEnumerable<DeliveryMethodRequestDTO>>(Method);
        }

        public async Task<OrderResultDTO> GetOrderByIDAsync(Guid Id)
        {
            var order = await unitOfWork.GetRepository<Order, Guid>().GetByIdAsync(new OrderIncludeSpecification(Id))
                  ?? throw new OrderNotFoundException(Id);
            return mapper.Map<OrderResultDTO>(order);

        }
    }
}
