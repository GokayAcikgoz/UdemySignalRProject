using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.SocialMediaDtos;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutSocialMediaComponentPartial : ViewComponent
	{
		
		private readonly IConsumeGenericMethod _consumeGenericMethod;

		public _UILayoutSocialMediaComponentPartial(IConsumeGenericMethod consumeGenericMethod)
		{
			_consumeGenericMethod = consumeGenericMethod;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _consumeGenericMethod.GetConsume<List<ResultSocialMediaDto>>("http://localhost:7052/api/SocialMedia");
			if (values != null)
			{
				return View(values);
			}
			return View();
		}
	}
	
}
