using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.UnitOfWork;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;
        private readonly IUoWDal _uowDal;
        public BasketManager(IBasketDal basketDal, IUoWDal uowDal)
        {
            _basketDal = basketDal;
            _uowDal = uowDal;
        }

        public void TAdd(Basket entity)
        {
            _basketDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
            _uowDal.Save();
        }

        public List<Basket> TGetBasketByMenuTableNumber(int id)
        {
            return _basketDal.GetBasketByMenuTableNumber(id);
        }

        public List<ResultBasketListWithProducts> TGetBasketListByMenuTableWithProductName(int id)
        {
            return _basketDal.GetBasketListByMenuTableWithProductName(id);
        }

        public Basket TGetByID(int id)
        {
            return _basketDal.GetByID(id);
        }

        public List<Basket> TGetListAll()
        {
            return _basketDal.GetListAll();
        }

        public void TUpdate(Basket entity)
        {
            _basketDal.Update(entity);
            _uowDal.Save();
        }
    }
}
