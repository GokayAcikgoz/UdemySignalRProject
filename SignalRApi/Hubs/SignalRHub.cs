using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;

		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
		}

		public async Task SendCategoryCount()
		{
			var value = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiverCategoryCount", value);
		}

        public async Task SendProductCount()
        {
            var value = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiverProductCount", value);
        }

		public async Task ActiveCategoryCount()
		{
			var value = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiverActiveCategoryCount", value);
		}

		public async Task PassiveCategoryCount()
		{
			var value = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceiverPassiveCategoryCount", value);
		}

		public async Task ProductCountByCategoryNameHamburger()
		{
			var value = _productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiverProductCountByCategoryNameHamburger", value);
		}

		public async Task ProductCountByCategoryNameDrink()
		{
			var value = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiverProductCountByCategoryNameDrink", value);
		}

		public async Task ProductPriceAvg()
		{
			var value = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReceiverProductPriceAvg", value.ToString("0.00") + " ₺");
		}

		public async Task ProductNameByMaxPrice()
		{
			var value = _productService.TProductNameByMaxPrice();
			await Clients.All.SendAsync("ReceiverProductNameByMaxPrice", value);
		}

		public async Task ProductNameByMinPrice()
		{
			var value = _productService.TProductNameByMinPrice();
			await Clients.All.SendAsync("ReceiverProductNameByMinPrice", value);
		}

		public async Task ProductAvgPriceByHamburger()
		{
			var value = _productService.TProductAvgPriceByHamburger();
			await Clients.All.SendAsync("ReceiverProductAvgPriceByHamburger", value.ToString("0.00") + " ₺");
		}

		public async Task TotalOrderCount()
		{
			var value = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiverTotalOrderCount", value);
		}

		public async Task ActiveOrderCount()
		{
			var value = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiverActiveOrderCount", value);
		}

		public async Task LastOrderPrice()
		{
			var value = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReceiverLastOrderPrice", value);
		}

		public async Task TotalMoneyCaseAmount()
		{
			var value = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiverTotalMoneyCaseAmount", value.ToString("0.00") + " ₺");
		}

		public async Task MenuTableCount()
		{
			var value = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiverMenuTableCount", value);
		}
		
		public async Task TodayTotalPrice()
		{
			var value = _orderService.TTodayTotalPrice();
			await Clients.All.SendAsync("ReceiverTodayTotalPrice", value.ToString("0.00") + " ₺");
		}

		public async Task SendProgress()
		{
			var value = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiverTotalMoneyCaseAmount", value.ToString("0.00") + " ₺");					
        }

		public async Task ProgressActiveOrderCount()
		{
            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiverActiveOrderCount", value2);
        }

		public async Task ProgressMenuTableCount()
		{
            var value3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiverMenuTableCount", value3);
        }
	}
}
