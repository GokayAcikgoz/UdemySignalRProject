using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.BookingDtos;

namespace SignalRWebUI.Controllers
{
    public class BookATableController : Controller
    {

        private readonly IConsumeGenericMethod _consumeGenericMethod;

        public BookATableController(IConsumeGenericMethod consumeGenericMethod)
        {
            _consumeGenericMethod = consumeGenericMethod;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            var value = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/Bookings", createBookingDto);
            if (value)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
