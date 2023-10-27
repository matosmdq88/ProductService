using AutoMapper;
using Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductsService.Pipelines.Exceptions;

namespace ProductsService.Features.Categories.GetAll
{
    public class GetAllHander : IRequestHandler<GetAllQuery, List<GetAllDTO>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllHander(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetAllDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _context.Categories.ToListAsync();
                return _mapper.Map<List<GetAllDTO>>(response);
            }
            catch (Exception ex)
            {
                ex.SetHandler(this);
                throw;
            }
        }
    }
}
