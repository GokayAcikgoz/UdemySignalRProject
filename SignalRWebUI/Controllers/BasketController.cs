using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.BasketDtos;

namespace SignalRWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IConsumeGenericMethod _consumeGenericMethod;

        public BasketController(IConsumeGenericMethod consumeGenericMethod)
        {
            _consumeGenericMethod = consumeGenericMethod;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _consumeGenericMethod.GetConsume<List<ResultBasketDto>>("http://localhost:7052/api/Baskets/BasketListByMenuTableWithProductName?id=4");
            if (values != null)
            {
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            var value = await _consumeGenericMethod.DeleteConsume("http://localhost:7052/api/Baskets", id);
            if (value)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }
        
    }
}
