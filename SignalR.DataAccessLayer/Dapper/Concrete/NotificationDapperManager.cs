using Dapper;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Dapper.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Dapper.Concrete
{
    public class NotificationDapperManager : INotificationDapperRepository
    {
        private readonly IDbConnection _connection;
        public NotificationDapperManager(SignalRContext context)
        {
            _connection = context.GetConnection();
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using (_connection)
            {
                _connection.Open();
                var query = @"SELECT * from Notifications where Status = 0";
                var result = _connection.Query<Notification>(query).ToList();
                return result;
            }
        }

        public int NotificationCountByStatusFalse()
        {
            using (_connection)
            {
                _connection.Open();
                var query = @"SELECT COUNT(*) from Notifications where Status = 0";
                var result = _connection.ExecuteScalar<int>(query);
                return result;
            }
        }
    }
}
