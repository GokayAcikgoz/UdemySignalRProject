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
	public class MoneyCaseManager : IMoneyCaseService
	{
		private readonly IMoneyCaseDal _moneyCaseDal;
		private readonly IUoWDal _uowDal;
		private readonly IMoneyCaseDapperRepository _moneyCaseDapperRepository;

		public MoneyCaseManager(IMoneyCaseDal moneyCaseDal, IUoWDal uowDal, IMoneyCaseDapperRepository moneyCaseDapperRepository)
		{
			_moneyCaseDal = moneyCaseDal;
			_uowDal = uowDal;
			_moneyCaseDapperRepository = moneyCaseDapperRepository;
		}

		public void TAdd(MoneyCase entity)
		{
			_moneyCaseDal.Add(entity);
			_uowDal.Save();
		}

		public void TDelete(MoneyCase entity)
		{
			_moneyCaseDal.Delete(entity);
			_uowDal.Save();
		}

		public MoneyCase TGetByID(int id)
		{
			return _moneyCaseDal.GetByID(id);
		}

		public List<MoneyCase> TGetListAll()
		{
			return _moneyCaseDal.GetListAll();
		}

		public decimal TTotalMoneyCaseAmount()
		{
			return _moneyCaseDapperRepository.TotalMoneyCaseAmount();
		}

		public void TUpdate(MoneyCase entity)
		{
			_moneyCaseDal.Update(entity);
			_uowDal.Save();
		}
	}
}
