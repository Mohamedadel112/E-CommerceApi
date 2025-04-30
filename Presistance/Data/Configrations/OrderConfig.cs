using Domain.Entities.OrderEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Data.Configrations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o => o.ShippingAddress, s => s.WithOwner());
            builder.HasMany(o => o.OrderItems).WithOne();
            builder.Property(o => o.OrderPaymentStatus).HasConversion(op => op.ToString(), s => Enum.Parse<OrderPaymentStatus>(s));
            builder.HasOne(o => o.DeliveryMethod).WithMany().OnDelete(DeleteBehavior.SetNull);
            builder.Property(o => o.SupTotal).HasColumnType("decimal(18,3)");
        }
    }
}
