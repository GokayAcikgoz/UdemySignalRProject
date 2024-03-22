using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountsController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            //_contactService.TAdd(new Contact()
            //{
            //    FooterDescription = createContactDto.FooterDescription,
            //    Location = createContactDto.Location,
            //    Mail = createContactDto.Mail,
            //    Phone = createContactDto.Phone
            //});
            _discountService.TAdd(_mapper.Map<Discount>(createDiscountDto));
            return Ok("İndirim bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            _discountService.TDelete(value);
            return Ok("İndirim bilgisi silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            //_contactService.TUpdate(new Contact()
            //{
            //    ContactID = updateContactDto.ContactID,
            //    FooterDescription =updateContactDto.FooterDescription,
            //    Phone = updateContactDto.Phone,
            //    Mail = updateContactDto.Mail,
            //    Location = updateContactDto.Location
            //});
            _discountService.TUpdate(_mapper.Map<Discount>(updateDiscountDto));
            return Ok("İletişim bilgisi eklendi");
        }
    }
}
