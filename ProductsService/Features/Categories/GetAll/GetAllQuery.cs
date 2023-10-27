using MediatR;

namespace ProductsService.Features.Categories.GetAll
{
    public class GetAllQuery : IRequest<List<GetAllDTO>>
    {
    }
}
