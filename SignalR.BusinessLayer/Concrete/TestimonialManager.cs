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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;
        private readonly IUoWDal _uowDal;

        public TestimonialManager(ITestimonialDal testimonialDal, IUoWDal uowDal)
        {
            _testimonialDal = testimonialDal;
            _uowDal = uowDal;
        }

        public void TAdd(Testimonial entity)
        {
            _testimonialDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Testimonial entity)
        {
            _testimonialDal.Delete(entity);
            _uowDal.Save();
        }

        public Testimonial TGetByID(int id)
        {
            return _testimonialDal.GetByID(id);
        }

        public List<Testimonial> TGetListAll()
        {
            return _testimonialDal.GetListAll();
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonialDal.Update(entity);
            _uowDal.Save();
        }
    }
}
