using AutoMapper;
using EcommerceNetBlazor.Model;
using EcommerceNetBlazor.Shared.DTOs;

namespace EcommerceNetBlazor.Util
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.Category, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<User, SessionDTO>();
            CreateMap<SaleDetail, SaleDetailDTO>().ReverseMap();

            CreateMap<Sale, SaleDTO>()
                .ForMember(dest => dest.SalesDetailsDTO, opt => opt.MapFrom(src => src.SalesDetails))
                .ReverseMap();

            CreateMap<User, UserDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ReverseMap();


            //CreateMap<User, RegisterDTO>()
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //.ReverseMap();
        }
    }
}