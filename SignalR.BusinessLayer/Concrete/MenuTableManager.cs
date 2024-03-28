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
	public class MenuTableManager : IMenuTableService
	{
		private readonly IMenuTableDal _menuTableDal;
		private readonly IUoWDal _uoWDal;
		private readonly IMenuTableDapperRepository _menuTableDapperRepository;

		public MenuTableManager(IUoWDal uoWDal, IMenuTableDal menuTableDal, IMenuTableDapperRepository menuTableDapperRepository)
		{
			_uoWDal = uoWDal;
			_menuTableDal = menuTableDal;
			_menuTableDapperRepository = menuTableDapperRepository;
		}

		public void TAdd(MenuTable entity)
		{
			_menuTableDal.Add(entity);
			_uoWDal.Save();
		}

		public void TDelete(MenuTable entity)
		{
			_menuTableDal.Delete(entity);
			_uoWDal.Save();
		}

		public MenuTable TGetByID(int id)
		{
			return _menuTableDal.GetByID(id);
		}

		public List<MenuTable> TGetListAll()
		{
			return _menuTableDal.GetListAll();
		}

		public int TMenuTableCount()
		{
			return _menuTableDapperRepository.MenuTableCount();
		}

		public void TUpdate(MenuTable entity)
		{
			_menuTableDal.Update(entity);
			_uoWDal.Save();
		}
	}
}
