using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IBasketRepo
    {

        //Get Basket 
        Task<CustomerBasket?> GetBasketAsync(string id);

        //Delete Basket
        Task<bool> DeleteBasketAsync(string id);

        //Create Basket

        Task<CustomerBasket?> CreateBasketAsync(CustomerBasket Basket , TimeSpan? timetolive=null);




    }
}
