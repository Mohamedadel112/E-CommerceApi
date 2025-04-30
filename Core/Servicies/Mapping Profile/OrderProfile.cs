using AutoMapper;
using Domain.Entities;
using Domain.Entities.OrderEntity;
using Microsoft.AspNetCore.Identity;
using Shared.DTOs;
using Shiping  = Domain.Entities.OrderEntity.Address;
namespace Servicies.Mapping_Profile
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Shiping, AddressDTO>().ReverseMap();
            CreateMap<DeliveryMethods, DeliveryMethodRequestDTO>();
            CreateMap<Domain.Entities.Address, AddressDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemsDTO>()
                .ForMember(des => des.ProductId, op => op.MapFrom(src => src.Product.ProductId))
                .ForMember(des => des.ProductName, op => op.MapFrom(src => src.Product.ProductName))
                .ForMember(des => des.ProductPicture, op => op.MapFrom(src => src.Product.ProductPicture));

            CreateMap<Order, OrderResultDTO>()
                .ForMember(des => des.OrderPaymentStatus, op => op.MapFrom(src => src.ToString()))
                .ForMember(des => des.DeliveryMethod, op => op.MapFrom(src => src.DeliveryMethod.Shortname))
                .ForMember(des => des.Total, op => op.MapFrom(s => s.SupTotal + s.DeliveryMethod.Price));








        }
    }
}
