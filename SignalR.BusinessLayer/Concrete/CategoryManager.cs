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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IUoWDal _uoWDal;
        private readonly ICategoryDapperRepository _categoryDapperRepository;

		public CategoryManager(ICategoryDal categoryDal, IUoWDal uoWDal, ICategoryDapperRepository categoryDapperRepository)
		{
			_categoryDal = categoryDal;
			_uoWDal = uoWDal;
			_categoryDapperRepository = categoryDapperRepository;
		}

		public int TActiveCategoryCount()
		{
			return _categoryDapperRepository.ActiveCategoryCount();
		}

		public void TAdd(Category entity)
        {
            _categoryDal.Add(entity);
            _uoWDal.Save();
        }

		public int TCategoryCount()
		{
            return _categoryDapperRepository.CategoryCount();
		}

		public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
            _uoWDal.Save();
        }

        public Category TGetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> TGetListAll()
        {
            return _categoryDal.GetListAll();
        }

		public int TPassiveCategoryCount()
		{
			return _categoryDapperRepository.PassiveCategoryCount();
		}

		public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
            _uoWDal.Save();
        }
    }
}
