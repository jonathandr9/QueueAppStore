using AutoMapper;
using QueueAppStore.API.Models;
using QueueAppStore.Domain.Models;

namespace QueueAppStore.API
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            CreateMap<LoginPost, User>()
                .ForMember(o => o.UserName, d => d.MapFrom(src => src.Login));

            CreateMap<RegisterPost, Client>();
            CreateMap<RegisterPost, User>();
            CreateMap<OrderPost, Order>();
            CreateMap<CardOrderPost, Card>()
                .ForMember(o => o.ValidThru, d => d.MapFrom(src => getValidThru(src.ValidThru)));
        }

        private DateTime getValidThru(string value)
        {
            return new DateTime(Convert.ToInt32(value.Split('/')[1]),
                Convert.ToInt32(value.Split('/')[0]),
                01);
        }
    }
}
