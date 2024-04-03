using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.MessageDto;
using SignalRWebUI.Core;

namespace SignalRWebUI.Controllers
{
    public class DefaultController : Controller
    {
		private readonly IConsumeGenericMethod _consumeGenericMethod;

		public DefaultController(IConsumeGenericMethod consumeGenericMethod)
		{
			_consumeGenericMethod = consumeGenericMethod;
		}

		public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

		[HttpPost]
		public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
		{
			var value = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/Messages", createMessageDto);
			if (value)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
