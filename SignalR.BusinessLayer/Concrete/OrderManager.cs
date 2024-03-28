using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Dapper.Abstract;
using SignalR.DataAccessLayer.UnitOfWork;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;
		private readonly IUoWDal _uowDal;
		private readonly IOrderDapperRepository _orderDapperRepository;
		public OrderManager(IOrderDal orderDal, IUoWDal uowDal, IOrderDapperRepository orderDapperRepository)
		{
			_orderDal = orderDal;
			_uowDal = uowDal;
			_orderDapperRepository = orderDapperRepository;
		}

		public int TActiveOrderCount()
		{
			return _orderDapperRepository.ActiveOrderCount();
		}

		public void TAdd(Order entity)
		{
			_orderDal.Add(entity);
			_uowDal.Save();
		}

		public void TDelete(Order entity)
		{
			_orderDal.Delete(entity);	
			_uowDal.Save();
		}

		public Order TGetByID(int id)
		{
			return _orderDal.GetByID(id);
		}

		public List<Order> TGetListAll()
		{
			return _orderDal.GetListAll();
		}

		public decimal TLastOrderPrice()
		{
			return _orderDapperRepository.LastOrderPrice();
		}

		public decimal TTodayTotalPrice()
		{
			return _orderDapperRepository.TodayTotalPrice();
		}

		public int TTotalOrderCount()
		{
			return _orderDapperRepository.TotalOrderCount();
		}

		public void TUpdate(Order entity)
		{
			_orderDal.Update(entity);
			_uowDal.Save();
		}
	}
}
