using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ServiciesApstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    public class ServicesManager : IServicesManager
    {
        private readonly Lazy<IProductServices> _productServices;
        private readonly Lazy<IBasketService> _basketServices;
        private readonly Lazy<IAuthenticationService> _authentication;
        private readonly Lazy<IOrderServices> _orderservice;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ServicesManager(IUnitOfWork unitOfWork, IMapper mapper , IBasketRepo basketRepo,UserManager<User> user,IOptions<JwtOptions> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productServices = new Lazy<IProductServices>(() => new ProductServices(_unitOfWork, _mapper));
            _basketServices = new Lazy<IBasketService>(() => new BasketService(basketRepo, _mapper));
            _authentication = new Lazy<IAuthenticationService>(()=>new AuthenticationService(user,mapper,options));
            _orderservice = new Lazy<IOrderServices>(() => new OrderServices(mapper, basketRepo, unitOfWork));
        }

        public IProductServices ProductServices => _productServices.Value;

        public IBasketService BasketServices => _basketServices.Value;

        public IAuthenticationService AuthenticationService => _authentication.Value;

        public IOrderServices MyProperty => _orderservice.Value;

        public IOrderServices OrderServices => _orderservice.Value;
    }
}
