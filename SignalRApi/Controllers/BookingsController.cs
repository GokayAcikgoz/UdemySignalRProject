using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var value = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            //Booking booking = new Booking
            //{
            //    Mail = createBookingDto.Mail,
            //    Date = createBookingDto.Date,
            //    Name = createBookingDto.Name,
            //    PersonCount = createBookingDto.PersonCount,
            //    Phone = createBookingDto.Phone
            //};

            _bookingService.TAdd(_mapper.Map<Booking>(createBookingDto));

            return Ok("Rezervasyon Yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok("Reservasyon silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            //Booking booking = new Booking
            //{
            //    BookingID = updateBookingDto.BookingID,
            //    Mail = updateBookingDto.Mail,
            //    Date = updateBookingDto.Date,
            //    Name = updateBookingDto.Name,
            //    PersonCount = updateBookingDto.PersonCount,
            //    Phone = updateBookingDto.Phone
            //};

            _bookingService.TUpdate(_mapper.Map<Booking>(updateBookingDto));
            return Ok("Rezervasyon Güncellendi");

        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.BookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }

		[HttpGet("BookingStatusCancelled/{id}")]
		public IActionResult BookingStatusCancelled(int id)
		{
			_bookingService.BookingStatusCancelled(id);
			return Ok("Rezervasyon Açıklaması Değiştirildi");
		}

	}
}

