using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerApi.Core.Dtos;
using NLayerApi.Core.Entities;
using NLayerApi.Core.Repositories;
using NLayerApi.Core.Service;

namespace NLayerApi.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _serviceProduct;
        private readonly IProductService _mainproductService;

        public ProductsController(IMapper mapper, IService<Product> serviceProduct, IProductService mainproductService)
        {
            _mapper = mapper;
            _serviceProduct = serviceProduct;
            _mainproductService = mainproductService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCategory()
        {
            return CreateActionResault(await _mainproductService.GetProductWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var defaultData = await _serviceProduct.GetAllAsync();
            var mappedData = _mapper.Map<List<ProductDto>>(defaultData.ToList());
            return CreateActionResault(CustomResponseDto<List<ProductDto>>.Succsess(200, mappedData));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _serviceProduct.GetById(id);
            var mappedData = _mapper.Map<ProductDto>(getId);
            return CreateActionResault(CustomResponseDto<ProductDto>.Succsess(200, mappedData));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {     
           var mappedDataConverter = _mapper.Map<Product>(productDto);
           var savedData= await _serviceProduct.AddAsync(mappedDataConverter);
           var mappedDataResault = _mapper.Map<ProductDto>(savedData);
            return CreateActionResault(CustomResponseDto<ProductDto>.Succsess(201, mappedDataResault));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            var mappedDataConverter = _mapper.Map<Product>(productDto);
             _serviceProduct.Update(mappedDataConverter);
            return CreateActionResault(CustomResponseDto<NoContentResponseDto>.Succsess(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var getId = await _serviceProduct.GetById(id);
             _serviceProduct.Remove(getId);
            return CreateActionResault(CustomResponseDto<NoContentResponseDto>.Succsess(204));
        }

    }
}
