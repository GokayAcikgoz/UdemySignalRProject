using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Dapper.Abstract;
using SignalR.DataAccessLayer.UnitOfWork;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        private readonly IUoWDal _uoWDal;
        private readonly INotificationDapperRepository _notificationDapperRepository;

        public NotificationManager(IUoWDal uoWDal, INotificationDal notificationDal, INotificationDapperRepository notificationDapperRepository)
        {
            _uoWDal = uoWDal;
            _notificationDal = notificationDal;
            _notificationDapperRepository = notificationDapperRepository;
        }

		public void TNotificationStatusChangeToFalse(int id)
		{
			_notificationDal.NotificationStatusChangeToFalse(id);
			
		}

		public void TNotificationStatusChangeToTrue(int id)
		{
            _notificationDal.NotificationStatusChangeToTrue(id);
			
		}

		public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
            _uoWDal.Save();
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
            _uoWDal.Save();
        }

        public List<Notification> TGetAllNotificationByFalse()
        {
            return _notificationDapperRepository.GetAllNotificationByFalse();
        }

        public Notification TGetByID(int id)
        {
            return _notificationDal.GetByID(id);
        }

        public List<Notification> TGetListAll()
        {
            return _notificationDal.GetListAll();
        }

        public int TNotificationCountByStatusFalse()
        {
            return _notificationDapperRepository.NotificationCountByStatusFalse();
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
            _uoWDal.Save();
        }
    }
}
