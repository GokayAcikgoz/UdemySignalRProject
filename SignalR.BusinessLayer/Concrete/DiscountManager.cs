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
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;
        private readonly IUoWDal _uowDal;

        public DiscountManager(IDiscountDal discountDal, IUoWDal uowDal)
        {
            _discountDal = discountDal;
            _uowDal = uowDal;
        }

        public void TAdd(Discount entity)
        {
            _discountDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Discount entity)
        {
            _discountDal.Delete(entity);
            _uowDal.Save();
        }

        public Discount TGetByID(int id)
        {
            return _discountDal.GetByID(id);
        }

        public List<Discount> TGetListAll()
        {
            return _discountDal.GetListAll();
        }

        public void TUpdate(Discount entity)
        {
            _discountDal.Update(entity);
            _uowDal.Save();
        }
    }
}
