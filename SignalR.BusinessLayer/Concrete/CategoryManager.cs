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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IUoWDal _uoWDal;

        public CategoryManager(ICategoryDal categoryDal, IUoWDal uoWDal)
        {
            _categoryDal = categoryDal;
            _uoWDal = uoWDal;
        }

        public void TAdd(Category entity)
        {
            _categoryDal.Add(entity);
            _uoWDal.Save();
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

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
            _uoWDal.Save();
        }
    }
}
