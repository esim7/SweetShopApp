using AutoMapper;
using Domain.Model;
using WebApp.Models;
using WebApp.Models.Customer;
using WebApp.Models.Order;
using WebApp.Models.OrderDetail;
using WebApp.Models.Product;

namespace WebApp
{
    public  class MapperConfig
    {
        //public static IMapper GetMapper()
        //{
        //    var config = new MapperConfiguration(x =>
        //    {
        //        x.CreateMap<Customer, CustomerViewModel>();
        //        x.CreateMap<Order, OrderViewModel>();
        //        x.CreateMap<OrderDetail, OrderDetailsViewModel>();
        //        x.CreateMap<Product, ProductViewModel>();
        //    });

        //    var mapper = config.CreateMapper();

        //    return mapper;
        //}

        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<CreateProductViewModel, Product>();
                cfg.CreateMap<EditProductViewModel, Product>();
                cfg.CreateMap<Product, EditProductViewModel>();
                cfg.CreateMap<Product, DeleteProductViewModel>();
                cfg.CreateMap<Order, OrderViewModel>();
                cfg.CreateMap<Customer, CustomerViewModel>();
                cfg.CreateMap<CreateCustomerViewModel, Customer>();
                cfg.CreateMap<Customer, EditCustomerViewModel>();
                cfg.CreateMap<EditCustomerViewModel, Customer>();
                cfg.CreateMap<Customer, DeleteCustomerViewModel>();
                cfg.CreateMap<DeleteCustomerViewModel, Customer>();
                cfg.CreateMap<Order, CreateOrderViewModel>();
                cfg.CreateMap<CreateOrderViewModel, Order>();
                cfg.CreateMap<Order, EditOrderViewModel>();
                cfg.CreateMap<EditOrderViewModel, Order>();
                cfg.CreateMap<Order, DeleteOrderViewModel>();
                cfg.CreateMap<DeleteOrderViewModel, Order>();
                cfg.CreateMap<OrderDetail, OrderDetailsViewModel>();
                cfg.CreateMap<OrderDetailsViewModel, OrderDetail>();
                cfg.CreateMap<OrderDetail, CreateOrderDetailsViewModel>();
                cfg.CreateMap<CreateOrderDetailsViewModel, OrderDetail>();
                cfg.CreateMap<OrderDetail, EditOrderDetailsViewModel>();
                cfg.CreateMap<EditOrderDetailsViewModel, OrderDetail>();
                cfg.CreateMap<OrderDetail, DeleteOrderDetailsViewModel>();
                cfg.CreateMap<DeleteOrderDetailsViewModel, OrderDetail>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}