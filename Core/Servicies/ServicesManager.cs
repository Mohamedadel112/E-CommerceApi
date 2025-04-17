using AutoMapper;
using Domain.Contracts;
using ServiciesApstraction;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ServicesManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productServices = new Lazy<IProductServices>(() => new ProductServices(_unitOfWork, _mapper));
        }

        public IProductServices ProductServices => _productServices.Value;
    }
}
