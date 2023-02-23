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
    [ApiVersion("1.0", Deprecated = true)]
    public class CustomerController : Controller
    {
        private readonly ICustomerApplication _customerApplication;

        public CustomerController(ICustomerApplication customerApplication) => _customerApplication = customerApplication;

        #region Sync Methods

        [HttpPost]
        [SwaggerOperation(
            Description = "Create a new customer",
            Tags = new[] { "Customer" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [ProducesResponseType(500)]
        [Route("Insert")]
        public IActionResult Insert([FromBody] CustomerDto customerDto)
        {
            if (customerDto is null)
                return BadRequest();

            Response<bool> response = _customerApplication.Insert(customerDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut]
        [SwaggerOperation(
            Description = "update a customer",
            Tags = new[] { "Customer" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [ProducesResponseType(500)]
        [Route("Update/{customerId}")]
        public IActionResult Update(string customerId, [FromBody] CustomerDto customerDto)
        {
            if (customerDto is null || string.IsNullOrWhiteSpace(customerId))
                return BadRequest();

            Response<CustomerDto> customer = _customerApplication.Get(customerId);

            if (customer.Data is null)
                return NotFound(customer);


            Response<bool> response = _customerApplication.Update(customerDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete]
        [SwaggerOperation(
            Description = "Delete a customer",
            Tags = new[] { "Customer" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [ProducesResponseType(500)]
        [Route("Delete/{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();

            Response<bool> response = _customerApplication.Delete(customerId);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet]
        [SwaggerOperation(
            Description = "Get a customer",
            Tags = new[] { "Customer" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [ProducesResponseType(500)]
        [Route("Get/{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();

            Response<CustomerDto> response = _customerApplication.Get(customerId);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation(
            Description = "Get a customer",
            Tags = new[] { "Customer" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [ProducesResponseType(500)]
        [Route("PruebaGet/{customerId}")]
        public IActionResult PruebaGet(Mienum customerId)
        {
            return Ok(new { miId = customerId });
        }

        // POST: api/Customer/PruebaInsert
        /// <summary>
        /// Crea un nuevo objeto en la BD.
        /// </summary>
        /// <remarks>
        /// Aquí una descripción mas larga si fuera necesario. Crea un nuevo objeto en la BD.
        /// </remarks>
        /// <param name="customerDto">Objeto a crear a la BD.</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>
        /// <response code="500">Server error. Error interno de servidor.</response>
        /// <returns>Obj respuesta con verdadero o falso de la peticion</returns>
        [HttpPost]
        [AllowAnonymous]
        [SwaggerOperation(
            Description = "Create a new customer",
            Tags = new[] { "Customer" }
        )]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("PruebaInsert")]
        public IActionResult PruebaInsert([FromBody] CustomerDto customerDto)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, customerDto);
        }

        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation(
            Description = "Get all customers",
            Tags = new[] { "Customer" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful", Type = typeof(Response<IEnumerable<CustomerDto>>))]
        [ProducesResponseType(500)]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            Response<IEnumerable<CustomerDto>> response = _customerApplication.GetAll();

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        #endregion

        #region Async Methods
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomerDto customerDto)
        {
            if (customerDto is null)
                return BadRequest();

            Response<bool> response = await _customerApplication.InsertAsync(customerDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("UpdateAsync/{customerId}")]
        public async Task<IActionResult> UpdateAsync(string customerId, [FromBody] CustomerDto customerDto)
        {
            Response<CustomerDto> customer = await _customerApplication.GetAsync(customerId);

            if (customer.Data is null)
                return NotFound(customer);

            if (customer is not null)
            {
                Response<bool> response = await _customerApplication.UpdateAsync(customerDto);

                if (response.IsSuccess)
                    return Ok(response);

                return BadRequest(response);
            }

            return BadRequest();
        }

        #endregion
    }

    public enum Mienum { elemento = 1 }
}