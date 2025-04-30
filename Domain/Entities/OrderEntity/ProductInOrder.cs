using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderEntity
{
    public class ProductInOrder
    {
        public ProductInOrder(int productId, string productName, string productPicture)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPicture = productPicture;
        }
        public ProductInOrder()
        {
            
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPicture { get; set; }
    }
}
