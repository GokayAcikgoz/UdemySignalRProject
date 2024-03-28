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
	public class MenuTableDapperManager : IMenuTableDapperRepository
	{
		private readonly IDbConnection _connection;
		public MenuTableDapperManager(SignalRContext context)
		{
			_connection = context.GetConnection();
		}
		public int MenuTableCount()
		{
			using (_connection)
			{
				_connection.Open();
				var query = @"SELECT COUNT(*) from MenuTables";
				var result = _connection.ExecuteScalar<int>(query);
				return result;
			}
		}
	}
}
