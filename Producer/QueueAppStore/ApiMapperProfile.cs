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
        }
    }
}
