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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;
        private readonly IUoWDal _uowDal;

        public SliderManager(ISliderDal sliderDal, IUoWDal uowDal)
        {
            _sliderDal = sliderDal;
            _uowDal = uowDal;
        }

        public void TAdd(Slider entity)
        {
            _sliderDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Slider entity)
        {
            _sliderDal.Delete(entity);
            _uowDal.Save();
        }

        public Slider TGetByID(int id)
        {
            return _sliderDal.GetByID(id);
        }

        public List<Slider> TGetListAll()
        {
            return _sliderDal.GetListAll();
        }

        public void TUpdate(Slider entity)
        {
            _sliderDal.Update(entity);
            _uowDal.Save();
        }
    }
}
