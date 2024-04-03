using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.NotificationDtos;
using System.Net.Http;

namespace SignalRWebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IConsumeGenericMethod _consumeGenericMethod;
        private readonly IHttpClientFactory _httpClientFactory;

		public NotificationController(IConsumeGenericMethod consumeGenericMethod, IHttpClientFactory httpClientFactory)
		{
			_consumeGenericMethod = consumeGenericMethod;
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
        {

            var values = await _consumeGenericMethod.GetConsume<List<ResultNotificationDto>>("http://localhost:7052/api/Notifications");
            if (values != null)
            {
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
    
            var value = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/Notifications", createNotificationDto);
            if (value)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteNotification(int id)
        {
            var value = await _consumeGenericMethod.DeleteConsume("http://localhost:7052/api/Notifications", id);
            if (value)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var values = await _consumeGenericMethod.GetConsume<UpdateNotificationDto>("http://localhost:7052/api/Notifications", id);
            if (values != null)
            {
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var values = await _consumeGenericMethod.UpdateConsume("http://localhost:7052/api/Notifications/", updateNotificationDto);
            if (values)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

		public async Task<IActionResult> NotificationStatusChangeToTrue(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"http://localhost:7052/api/Notifications/NotificationStatusChangeToTrue/{id}");
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> NotificationStatusChangeToFalse(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"http://localhost:7052/api/Notifications/NotificationStatusChangeToFalse/{id}");
			return RedirectToAction("Index");
		}
	}
}
