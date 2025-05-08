using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using ServiciesApstraction;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    public class BasketService(IBasketRepo basketRepo , IMapper mapper) : IBasketService
    {
        private readonly IBasketRepo _basketRepo = basketRepo;
        private readonly IMapper _mapper = mapper;


        public async Task<BasketDTO?> CreateBasketAsync(BasketDTO basket)
        {
            var CustomerBasket = await _basketRepo.CreateBasketAsync(_mapper.Map<CustomerBasket>(basket));
            return CustomerBasket is null ? throw new Exception("Can't Update a Basket Now ") : _mapper.Map<BasketDTO>(CustomerBasket);
        }





        public async Task<BasketDTO?> GetBasketAsync(string id)
        {
            var basket =  await _basketRepo.GetBasketAsync(id);

            return basket is null ?throw new BasketNotFoundException(id): _mapper.Map<BasketDTO?>(basket);   
        }






        public async Task<bool> DeleteBasketAsync(string id) =>await _basketRepo.DeleteBasketAsync(id);
    }
}
