using Dapper;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Dapper.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Dapper.Concrete
{
	public class OrderDapperManager : IOrderDapperRepository
	{
		private readonly IDbConnection _connection;
		public OrderDapperManager(SignalRContext context)
		{
			_connection = context.GetConnection();
		}

		public int ActiveOrderCount()
		{
			using (_connection)
			{
				_connection.Open();
				var query = @"SELECT COUNT(*) From ORDERS WHERE Description='Müşteri Masada'";
				var result = _connection.ExecuteScalar<int>(query);
				return result;
			}
		}

		public decimal LastOrderPrice()
		{
			using (_connection)
			{
				_connection.Open();
				var query = @"SELECT TOP 1 * FROM ORDERS ORDER BY OrderID DESC";
				var result = _connection.ExecuteScalar<int>(query);
				return result;
			}
		}

		public decimal TodayTotalPrice()
		{
			string convertDate = DateTime.Now.ToString("yyyy-MM-dd");
			using (_connection)
			{
				_connection.Open();
				var query = @"select SUM(TotalPrice) from Orders where CONVERT(VARCHAR(10), Date, 120) = @convertDate";
				var result = _connection.ExecuteScalar<decimal>(query, new { convertDate });
				return result;
			}
		}

		public int TotalOrderCount()
		{
			using (_connection)
			{
				_connection.Open();
				var query = @"SELECT COUNT(*) from Orders";
				var result = _connection.ExecuteScalar<int>(query);
				return result;
			}
		}
	}
}
