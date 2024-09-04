using AutoMapper;
using EasyControl.Api.Contract.Areceber;
using EasyControl.Api.Domain.Models;

namespace EasyControl.Api.AutoMapper
{
    public class AreceberProfile : Profile
    {
        public AreceberProfile()
        {            
            CreateMap<Areceber, AreceberRequestContract>().ReverseMap();
            CreateMap<Areceber, AreceberResponseContract>().ReverseMap();
        }
    }
}