using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Base;
using ProductsService.Features.Categories.Create;
using ProductsService.Features.Categories.GetAll;
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


        [HttpPost("Create")]
        public async Task<ActionResult<BaseResponse<CreateResponseDTO>>> Create([FromBody]CreateCommand command)
        {
            var responseHandler = await _mediatr.Send(command);
            var response = new BaseResponse<CreateResponseDTO>(true, (int)HttpStatusCode.Created, data: responseHandler);
            return new ObjectResult(response);
        } 

        [HttpGet("GetAll")]
        public async Task<ActionResult<BaseResponse<List<GetAllDTO>>>> GetAll([FromQuery]GetAllQuery query)
        {
            var responseHandler = await _mediatr.Send(query);
            var response = new BaseResponse<List<GetAllDTO>>(true, (int)HttpStatusCode.OK, data: responseHandler);
            return new ObjectResult(response);
        }
    }
}
