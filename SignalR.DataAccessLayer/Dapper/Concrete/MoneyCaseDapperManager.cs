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
	public class MoneyCaseDapperManager : IMoneyCaseDapperRepository
	{
		private readonly IDbConnection _connection;
		public MoneyCaseDapperManager(SignalRContext context)
		{
			_connection = context.GetConnection();
		}
		public decimal TotalMoneyCaseAmount()
		{
			using (_connection)
			{
				_connection.Open();
				var query = @"SELECT TotalAmount from MoneyCases";
				var result = _connection.ExecuteScalar<decimal>(query);
				return result;
			}
		}
	}
}
