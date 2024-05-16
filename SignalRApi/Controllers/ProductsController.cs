using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly FilesController _filesController;

        public ProductsController(IProductService productService, IMapper mapper, FilesController filesController)
        {
            _productService = productService;
            _mapper = mapper;
            _filesController = filesController;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }

		[HttpGet("ProductCount")]
		public IActionResult ProductCount()
		{
			return Ok(_productService.TProductCount());
		}

		[HttpGet("ProductCountByCategoryNameDrink")]
        public IActionResult ProductCountByCategoryNameDrink()
        {
            return Ok(_productService.TProductCountByCategoryNameDrink());
        }

		[HttpGet("ProductCountByCategoryNameHamburger")]
		public IActionResult ProductCountByCategoryNameHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}

		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());
		}

		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_productService.TProductNameByMaxPrice());
		}

		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_productService.TProductNameByMinPrice());
		}


		[HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var value = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            return Ok(value);
        }

		[HttpGet("ProductAvgPriceByHamburger")]
		public IActionResult ProductAvgPriceByHamburger()
		{
			return Ok(_productService.TProductAvgPriceByHamburger());
		}

		[HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDto createProductDto)
        {

			if (createProductDto.ImageUrl != null && createProductDto.ImageUrl.Length > 0)
			{
				var s3Result = await _filesController.UploadFileAsync(createProductDto.ImageUrl, "signalrudemy-bucket", null);

				if (s3Result is OkObjectResult okResult)
				{
					string imageUrl = okResult.Value as string;
					if (!string.IsNullOrEmpty(imageUrl))
					{
						var product = _mapper.Map<Product>(createProductDto);
						product.ImageUrl = imageUrl;

						_productService.TAdd(product);


						return Ok("Ürün Eklendi");
					}
				}
				return BadRequest("Resim yükleme sırasında bir hata oluştu.");
			}
			return BadRequest("Lütfen bir resim dosyası seçin.");

			//_productService.TAdd(_mapper.Map<Product>(createProductDto));
			//return Ok("Ürün bilgisi eklendi");
		}

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün bilgisi silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            //_contactService.TUpdate(new Contact()
            //{
            //    ContactID = updateContactDto.ContactID,
            //    FooterDescription =updateContactDto.FooterDescription,
            //    Phone = updateContactDto.Phone,
            //    Mail = updateContactDto.Mail,
            //    Location = updateContactDto.Location
            //});
            _productService.TUpdate(_mapper.Map<Product>(updateProductDto));
            return Ok("Öne çıkan bilgisi eklendi");
        }
    }
}
