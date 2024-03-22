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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IUoWDal _uowDal;

        public AboutManager(IAboutDal aboutDal, IUoWDal uowDal)
        {
            _aboutDal = aboutDal;
            _uowDal = uowDal;
        }

        public void TAdd(About entity)
        {
            _aboutDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
            _uowDal.Save();
        }

        public About TGetByID(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public List<About> TGetListAll()
        {
            return _aboutDal.GetListAll();
        }

        public void TUpdate(About entity)
        {
            _aboutDal.Update(entity);
            _uowDal.Save();
        }
    }
}
