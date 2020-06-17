using AutoMapper;
using Domain.Model;
using WebApp.Models;

namespace WebApp
{
    public  class MapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Customer, CustomerViewModel>();
                x.CreateMap<Order, OrderViewModel>();
                x.CreateMap<OrderDetail, OrderDetailsViewModel>();
                x.CreateMap<Product, ProductViewModel>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}