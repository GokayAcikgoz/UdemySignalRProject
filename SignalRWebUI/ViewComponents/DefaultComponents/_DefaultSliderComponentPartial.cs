using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.SliderDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {
        private readonly IConsumeGenericMethod _consumeGenericMethod;

        public _DefaultSliderComponentPartial(IConsumeGenericMethod consumeGenericMethod)
        {
            _consumeGenericMethod = consumeGenericMethod;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _consumeGenericMethod.GetConsume<List<ResultSliderDto>>("http://localhost:7052/api/Sliders");
            if (values != null)
            {
                return View(values);
            }
            return View();
        }
    }
}
