using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciesApstraction
{
    public interface IServicesManager
    {
        public IProductServices ProductServices { get; }
        public IBasketService BasketServices { get; }
        public IAuthenticationService AuthenticationService { get; }
        public IOrderServices OrderServices { get;  }
        public IPaymentService PaymentServices { get; }
    }
}
