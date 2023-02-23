using AutoMapper;
using Example.Ecommerce.Application.DTO;
using Example.Ecommerce.Application.Interface;
using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Transversal.Common.Generic;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Example.Ecommerce.Application.Main
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryDomain _categoryDomain;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public CategoryApplication(ICategoryDomain categoryDomain, IMapper mapper, IDistributedCache distributedCache) =>
            (_categoryDomain, _mapper, _distributedCache) = (categoryDomain, mapper, distributedCache);

        public async Task<Response<IEnumerable<CategoryDto>>> GetAllAsync()
        {
            Response<IEnumerable<CategoryDto>> response = new Response<IEnumerable<CategoryDto>>();
            const string cacheKey = "categoriesList";

            try
            {
                byte[]? redisCategories = await _distributedCache.GetAsync(cacheKey);

                if (redisCategories is null)
                {
                    IEnumerable<Category> categories = await _categoryDomain.GetAllAsync();

                    response.Data = _mapper.Map<IEnumerable<CategoryDto>>(categories);
                    if (response.Data != null)
                    {
                        byte[] serializedCategories = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response.Data));
                        DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                            .SetAbsoluteExpiration(DateTime.Now.AddHours(8))
                            .SetSlidingExpiration(TimeSpan.FromMinutes(60));

                        await _distributedCache.SetAsync(cacheKey, serializedCategories, options);
                    }
                    else
                    {
                        response.Data = JsonSerializer.Deserialize<IEnumerable<CategoryDto>>(redisCategories)!;
                    }
                }

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
    }
}
