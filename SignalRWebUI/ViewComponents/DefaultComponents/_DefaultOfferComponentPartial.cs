using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.DiscountDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial : ViewComponent
    {
        private readonly IConsumeGenericMethod _consumeGenericMethod;

        public _DefaultOfferComponentPartial(IConsumeGenericMethod consumeGenericMethod)
        {
            _consumeGenericMethod = consumeGenericMethod;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _consumeGenericMethod.GetConsume<List<ResultDiscountDto>>("http://localhost:7052/api/Discounts/GetListStatusToTrue");
            if (values != null)
            {
                return View(values);
            }
            return View();
        }
    }
}
