using AutoMapper;
using Example.Ecommerce.Application.DTO;
using Example.Ecommerce.Application.Interface;
using Example.Ecommerce.Application.Validator;
using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Transversal.Common.Generic;
using FluentValidation.Results;
using System;

namespace Example.Ecommerce.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        private readonly UserDtoValidator _userDtoValidator;

        public UserApplication(IUserDomain userDomain, IMapper mapper, UserDtoValidator userDtoValidator) =>
            (_userDomain, _mapper, _userDtoValidator) = (userDomain, mapper, userDtoValidator);

        public Response<UserDto> Authenticate(string username, string password)
        {
            Response<UserDto> response = new Response<UserDto>();

            ValidationResult validation = _userDtoValidator.Validate(new UserDto { UserName = username, Password = password });

            if (!validation.IsValid)
            {
                response.Message = "Parametros no pueden ser vacios";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                User user = _userDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UserDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticacion exitosa";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
