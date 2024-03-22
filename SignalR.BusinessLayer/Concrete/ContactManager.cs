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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IUoWDal _uowDal;

        public ContactManager(IContactDal contactDal, IUoWDal uowDal)
        {
            _contactDal = contactDal;
            _uowDal = uowDal;
        }

        public void TAdd(Contact entity)
        {
            _contactDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Contact entity)
        {
            _contactDal.Delete(entity);
            _uowDal.Save();
        }

        public Contact TGetByID(int id)
        {
            return _contactDal.GetByID(id);
        }

        public List<Contact> TGetListAll()
        {
            return _contactDal.GetListAll();
        }

        public void TUpdate(Contact entity)
        {
            _contactDal.Update(entity);
            _uowDal.Save();
        }
    }
}
