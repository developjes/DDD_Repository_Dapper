using Example.Ecommerce.Application.DTO;
using Example.Ecommerce.Application.Interface;
using Example.Ecommerce.Transversal.Common.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Swashbuckle.AspNetCore.Annotations;

namespace Example.Ecommerce.Service.WebApi.Controllers.v1
{
    [Authorize]
    [EnableRateLimiting("fixedWindow")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = false)]
    public class CategoryController : Controller
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication) => _categoryApplication = categoryApplication;

        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation(
            Description = "Get all categories",
            Tags = new[] { "Category" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful", Type = typeof(Response<IEnumerable<CategoryDto>>))]
        [ProducesResponseType(500)]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<CategoryDto>> response = await _categoryApplication.GetAllAsync();

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
