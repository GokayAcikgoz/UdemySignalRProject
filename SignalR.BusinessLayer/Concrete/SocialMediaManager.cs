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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;
        private readonly IUoWDal _uowDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal, IUoWDal uowDal)
        {
            _socialMediaDal = socialMediaDal;
            _uowDal = uowDal;
        }

        public void TAdd(SocialMedia entity)
        {
            _socialMediaDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(SocialMedia entity)
        {
            _socialMediaDal.Delete(entity);
            _uowDal.Save();
        }

        public SocialMedia TGetByID(int id)
        {
            return _socialMediaDal.GetByID(id);
        }

        public List<SocialMedia> TGetListAll()
        {
            return _socialMediaDal.GetListAll();
        }

        public void TUpdate(SocialMedia entity)
        {
            _socialMediaDal.Update(entity);
            _uowDal.Save();
        }
    }
}
