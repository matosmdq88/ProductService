using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ProductsService.Features.Categories.Create
{
    public class CreateCommand : IRequest<CreateResponseDTO>
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
    }
}
