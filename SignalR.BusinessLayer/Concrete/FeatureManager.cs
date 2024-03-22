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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;
        private readonly IUoWDal _uowDal;

        public FeatureManager(IFeatureDal featureDal, IUoWDal uowDal)
        {
            _featureDal = featureDal;
            _uowDal = uowDal;
        }

        public void TAdd(Feature entity)
        {
            _featureDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Feature entity)
        {
            _featureDal.Delete(entity);
            _uowDal.Save();
        }

        public Feature TGetByID(int id)
        {
            return _featureDal.GetByID(id);
        }

        public List<Feature> TGetListAll()
        {
            return _featureDal.GetListAll();
        }

        public void TUpdate(Feature entity)
        {
            _featureDal.Update(entity);
            _uowDal.Save();
        }
    }
}
