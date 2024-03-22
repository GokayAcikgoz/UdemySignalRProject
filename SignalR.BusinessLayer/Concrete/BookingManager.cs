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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;
        private readonly IUoWDal _uowDal;

        public BookingManager(IBookingDal bookingDal, IUoWDal uowDal)
        {
            _bookingDal = bookingDal;
            _uowDal = uowDal;
        }

        public void TAdd(Booking entity)
        {
            _bookingDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
            _uowDal.Save();
        }

        public Booking TGetByID(int id)
        {
            return _bookingDal.GetByID(id);
        }

        public List<Booking> TGetListAll()
        {
            return _bookingDal.GetListAll();
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
            _uowDal.Save();
        }
    }
}
