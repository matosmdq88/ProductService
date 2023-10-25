using AutoMapper;
using Core;
using Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductsService.Pipelines.Exceptions;

namespace ProductsService.Features.Categories.Create
{
    public class CreateHandler : IRequestHandler<CreateCommand, CreateResponseDTO>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CreateResponseDTO> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validName = await _context.Categories.FirstOrDefaultAsync(p => p.Name == request.Name);
                if (validName is not null)
                    throw new BussinessLogicalException("Category name already exist");

                var newCategory = _mapper.Map<Category>(request);
                newCategory =  _context.Categories.Add(newCategory).Entity;
                await _context.SaveChangesAsync();
                return _mapper.Map<CreateResponseDTO>(newCategory);
            }
            catch (Exception ex)
            {
                ex.SetHandler(this);
                throw;
            }
        }
    }
}
