using AutoMapper;
using Core.Models;
using ProductsService.Features.Categories.Create;

namespace ProductsService.Features.Categories
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<CreateCommand, Category>();
            CreateMap<Category, CreateResponseDTO>();
        }
    }
}
