using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.ContactDtos;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        private readonly IConsumeGenericMethod _consumeGenericMethod;

        public _UILayoutFooterComponentPartial(IConsumeGenericMethod consumeGenericMethod)
        {
            _consumeGenericMethod = consumeGenericMethod;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _consumeGenericMethod.GetConsume<List<ResultContactDto>>("http://localhost:7052/api/Contacts");
            if (values != null)
            {
                return View(values);
            }
            return View();
        }
    }
}
