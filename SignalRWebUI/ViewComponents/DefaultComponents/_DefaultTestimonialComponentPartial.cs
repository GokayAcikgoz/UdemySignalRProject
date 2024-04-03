using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.TestimonialDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
        private readonly IConsumeGenericMethod _consumeGenericMethod;

        public _DefaultTestimonialComponentPartial(IConsumeGenericMethod consumeGenericMethod)
        {
            _consumeGenericMethod = consumeGenericMethod;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _consumeGenericMethod.GetConsume<List<ResultTestimonialDto>>("http://localhost:7052/api/Testimonials");
            if (values != null)
            {
                return View(values);
            }
            return View();
        }
    }
}
