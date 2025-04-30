using Domain.Entities.OrderEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Data.Configrations
{
    public class DeliveryMethodConfig : IEntityTypeConfiguration<DeliveryMethods>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethods> builder)
        {
            builder.Property(d => d.Price).HasColumnType("decimal(18,3)");
        }
    }
}
