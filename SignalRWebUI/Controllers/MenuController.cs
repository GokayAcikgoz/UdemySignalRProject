using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IConsumeGenericMethod _consumeGenericMethod;

        public MenuController(IConsumeGenericMethod consumeGenericMethod)
        {
            _consumeGenericMethod = consumeGenericMethod;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _consumeGenericMethod.GetConsume<List<ResultProductWithCategory>>("http://localhost:7052/api/Products/ProductListWithCategory");
            if (values != null)
            {
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(int id)
        {
            CreateBasketDto createBasketDto = new CreateBasketDto();
            createBasketDto.ProductID = id;
            var value = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/Baskets", createBasketDto);
            if (value)
            {
                return RedirectToAction("Index");
            }
            return Json(createBasketDto);
        }
    }
}
