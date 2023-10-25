using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Base;
using ProductsService.Features.Categories.Create;
using System.Net;

namespace ProductsService.Features.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CategoriesController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }


        [HttpPost]
        public async Task<ActionResult<BaseResponse<CreateResponseDTO>>> Create(CreateCommand command)
        {
            var responseHandler = await _mediatr.Send(command);
            var response = new BaseResponse<CreateResponseDTO>(true, (int)HttpStatusCode.Created, data: responseHandler);
            return new ObjectResult(response);
        } 

        [HttpGet]
        public async Task<ActionResult<BaseResponse>> Get()
        {
            return new BaseResponse(true,200);
        }
    }
}
