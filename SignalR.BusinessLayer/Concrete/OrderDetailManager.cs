using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.UnitOfWork;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class OrderDetailManager : IOrderDetailService
	{
		private readonly IOrderDetailDal _orderDetailDal;
		private readonly IUoWDal _uowDal;

		public OrderDetailManager(IOrderDetailDal orderDetailDal, IUoWDal uowDal)
		{
			_orderDetailDal = orderDetailDal;
			_uowDal = uowDal;
		}

		public void TAdd(OrderDetail entity)
		{
			_orderDetailDal.Add(entity);
			_uowDal.Save();
		}

		public void TDelete(OrderDetail entity)
		{
			_orderDetailDal.Delete(entity);
			_uowDal.Save();
		}

		public OrderDetail TGetByID(int id)
		{
			return _orderDetailDal.GetByID(id);
		}

		public List<OrderDetail> TGetListAll()
		{
			return _orderDetailDal.GetListAll();
		}

		public void TUpdate(OrderDetail entity)
		{
			_orderDetailDal.Update(entity);
			_uowDal.Save();
		}
	}
}
