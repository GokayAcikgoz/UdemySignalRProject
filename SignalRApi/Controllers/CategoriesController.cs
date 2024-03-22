using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            //_categoryService.TAdd(new Category()
            //{
            //    CategoryName = createCategoryDto.CategoryName,
            //    CategoryStatus = true
            //});
            _categoryService.TAdd(_mapper.Map<Category>(createCategoryDto));

            return Ok("Kategori eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            _categoryService.TDelete(value);
            return Ok("Kategori silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            //_categoryService.TUpdate(new Category()
            //{
            //    CategoryName = updateCategoryDto.CategoryName,
            //    CategoryStatus = true
            //});
            _categoryService.TUpdate(_mapper.Map<Category>(updateCategoryDto));
            return Ok("Kategori eklendi");
        }
    }
}
