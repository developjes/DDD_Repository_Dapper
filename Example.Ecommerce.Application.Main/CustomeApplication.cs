using AutoMapper;
using Example.Ecommerce.Application.DTO;
using Example.Ecommerce.Application.Interface;
using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Transversal.Common.Generic;
using Example.Ecommerce.Transversal.Common.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Ecommerce.Application.Main
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly ICustomerDomain _customerDomain;
        private readonly IAppLogger<CustomerApplication> _logger;
        private readonly IMapper _mapper;

        public CustomerApplication(ICustomerDomain customerDomain, IMapper mapper, IAppLogger<CustomerApplication> logger) =>
            (_customerDomain, _mapper, _logger) = (customerDomain, mapper, logger);

        public Response<bool> Delete(string customerId)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response.Data = _customerDomain.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                    _logger.LogInformation(response.Message);
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(response.Message);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response.Data = await _customerDomain.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<CustomerDto> Get(string customerId)
        {
            Response<CustomerDto> response = new Response<CustomerDto>();
            try
            {
                Customer customer = _customerDomain.Get(customerId);
                response.Data = _mapper.Map<CustomerDto>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<CustomerDto>> GetAll()
        {
            Response<IEnumerable<CustomerDto>> response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                IEnumerable<Customer> customers = _customerDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomerDto>>> GetAllAsync()
        {
            Response<IEnumerable<CustomerDto>> response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                IEnumerable<Customer> customers = await _customerDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<CustomerDto>> GetAsync(string customerId)
        {
            Response<CustomerDto> response = new Response<CustomerDto>();
            try
            {
                Customer customer = await _customerDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomerDto>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Insert(CustomerDto customerDto)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);
                response.Data = _customerDomain.Insert(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<bool>> InsertAsync(CustomerDto customerDto)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);
                response.Data = await _customerDomain.InsertAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Update(CustomerDto customerDto)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);
                response.Data = _customerDomain.Update(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomerDto customerDto)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);
                response.Data = await _customerDomain.UpdateAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public ResponsePagination<IEnumerable<CustomerDto>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            ResponsePagination<IEnumerable<CustomerDto>> response = new ResponsePagination<IEnumerable<CustomerDto>>();
            try
            {
                int count = _customerDomain.Count();

                IEnumerable<Customer> customers = _customerDomain.GetAllWithPagination(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
                    response.Message = "Consulta Paginada Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponsePagination<IEnumerable<CustomerDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            ResponsePagination<IEnumerable<CustomerDto>> response = new ResponsePagination<IEnumerable<CustomerDto>>();
            try
            {
                int count = await _customerDomain.CountAsync();

                IEnumerable<Customer> customers = await _customerDomain.GetAllWithPaginationAsync(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
                    response.Message = "Consulta Paginada Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
