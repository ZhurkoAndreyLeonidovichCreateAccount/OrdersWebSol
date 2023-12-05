using AutoMapper;
using OrdersWeb.BLL.Models;
using OrdersWeb.DAL.Entity;

namespace OrdersWeb.BLL
{

    public class AppMappingProfile : Profile
    {
       
        public AppMappingProfile()
        {

                CreateMap<Order, OrderView>();


            CreateMap<CreateViewOrder, Order>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<Order, CreateViewOrder>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.ProviderId, opt => opt.MapFrom(src => src.ProviderId))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }

            //CreateMap<ShortendUrl, ShortendUrlView>()
            //.ForMember(dest => dest.ShortUrl, opt => opt.MapFrom(
            //    src => $"{_httpContextAccessor.HttpContext.Request.Scheme}/{_httpContextAccessor.HttpContext.Request.Host}/{src.Code}"
            //    ));      

    }
}
