using AutoMapper;
using NLayerApi.Core.Dtos;
using NLayerApi.Core.Entities;
using NLayerApi.Core.Repositories;
using NLayerApi.Core.Service;
using NLayerApi.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApi.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork uow, IProductRepository productRepository, IMapper mapper) : base(repository, uow)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategory()
        {
            var data = await _productRepository.GetProductWithCategory();
            var mappedData = _mapper.Map<List<ProductWithCategoryDto>>(data);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Succsess(200, mappedData);
        }
    }
}
