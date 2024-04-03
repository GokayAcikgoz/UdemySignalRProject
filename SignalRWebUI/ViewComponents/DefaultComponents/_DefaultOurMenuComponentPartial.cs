using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial : ViewComponent
    {
        private readonly IConsumeGenericMethod _consumeGenericMethod;

        public _DefaultOurMenuComponentPartial(IConsumeGenericMethod consumeGenericMethod)
        {
            _consumeGenericMethod = consumeGenericMethod;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _consumeGenericMethod.GetConsume<List<ResultProductWithCategory>>("http://localhost:7052/api/Products/ProductListWithCategory");
            if (values != null)
            {
                return View(values);
            }
            return View();
        }
    }
}
