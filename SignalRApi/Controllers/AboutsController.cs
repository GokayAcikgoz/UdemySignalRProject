using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutsController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var value = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            //About about = new About
            //{
            //    Description = createAboutDto.Description,
            //    ImageUrl = createAboutDto.ImageUrl,
            //    Title = createAboutDto.Title,
            //};
            _aboutService.TAdd(_mapper.Map<About>(createAboutDto));

            return Ok("Hakkımda eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda alanı silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            //About about = new About
            //{
            //    AboutID = updateAboutDto.AboutID,
            //    Description = updateAboutDto.Description,
            //    ImageUrl = updateAboutDto.ImageUrl,
            //    Title = updateAboutDto.Title,
            //};
            _aboutService.TUpdate(_mapper.Map<About>(updateAboutDto));
            return Ok("Kategori Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(value);
        }
    }
}
