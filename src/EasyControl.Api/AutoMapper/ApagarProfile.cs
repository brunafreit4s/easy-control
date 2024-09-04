using AutoMapper;
using EasyControl.Api.Contract.Apagar;
using EasyControl.Api.Domain.Models;

namespace EasyControl.Api.AutoMapper
{
    public class ApagarProfile : Profile
    {
        public ApagarProfile()
        {            
            CreateMap<Apagar, ApagarRequestContract>().ReverseMap();
            CreateMap<Apagar, ApagarResponseContract>().ReverseMap();
        }
    }
}