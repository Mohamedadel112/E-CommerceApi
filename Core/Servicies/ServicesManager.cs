using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly Lazy<IPaymentService> _paymentservice;
        private readonly Lazy<CacheService> _cacheservice;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ServicesManager(IUnitOfWork unitOfWork, IMapper mapper ,ICacheReepo CacheRepo,
            IBasketRepo basketRepo,UserManager<User> user,IOptions<JwtOptions> options,IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productServices = new Lazy<IProductServices>(() => new ProductServices(_unitOfWork, _mapper));
            _basketServices = new Lazy<IBasketService>(() => new BasketService(basketRepo, _mapper));
            _authentication = new Lazy<IAuthenticationService>(()=>new AuthenticationService(user,mapper,options));
            _orderservice = new Lazy<IOrderServices>(() => new OrderServices(mapper, basketRepo, unitOfWork));
            _paymentservice = new Lazy<IPaymentService>(() => new PaymentService(basketRepo, mapper, configuration, unitOfWork));
            _cacheservice = new Lazy<CacheService>(() => new CacheService(CacheRepo));
        }

        public IProductServices ProductServices => _productServices.Value;

        public IBasketService BasketServices => _basketServices.Value;

        public IAuthenticationService AuthenticationService => _authentication.Value;

        public IOrderServices MyProperty => _orderservice.Value;

        public IOrderServices OrderServices => _orderservice.Value;

        public IPaymentService PaymentServices => _paymentservice.Value;

        public ICacheService CacheServices => _cacheservice.Value;
    }
}
