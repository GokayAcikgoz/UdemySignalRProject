using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeaturesController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var value = _mapper.Map<List<ResultFeaturDto>>(_featureService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            //_contactService.TAdd(new Contact()
            //{
            //    FooterDescription = createContactDto.FooterDescription,
            //    Location = createContactDto.Location,
            //    Mail = createContactDto.Mail,
            //    Phone = createContactDto.Phone
            //});
            _featureService.TAdd(_mapper.Map<Feature>(createFeatureDto));
            return Ok("Öne çıkan bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetByID(id);
            _featureService.TDelete(value);
            return Ok("Öne çıkan bilgisi silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            //_contactService.TUpdate(new Contact()
            //{
            //    ContactID = updateContactDto.ContactID,
            //    FooterDescription =updateContactDto.FooterDescription,
            //    Phone = updateContactDto.Phone,
            //    Mail = updateContactDto.Mail,
            //    Location = updateContactDto.Location
            //});
            _featureService.TUpdate(_mapper.Map<Feature>(updateFeatureDto));
            return Ok("Öne çıkan bilgisi eklendi");
        }
    }
}
