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
	public class CategoryDapperManager : ICategoryDapperRepository
	{
		private readonly IDbConnection _connection;
		public CategoryDapperManager(SignalRContext context)
		{
			_connection = context.GetConnection();
		}

		public int ActiveCategoryCount()
		{
			using (_connection)
			{
				_connection.Open();
				var query = @"SELECT COUNT(*) from Categories where CategoryStatus = 1";
				var result = _connection.ExecuteScalar<int>(query);
				return result;
			}
		}

		public int CategoryCount()
		{
			using (_connection)
			{
				_connection.Open();
				var query = @"SELECT COUNT(*) FROM Categories";
				var result = _connection.ExecuteScalar<int>(query);
				return result;
			}
		}

		public int PassiveCategoryCount()
		{
			using (_connection)
			{
				_connection.Open();
				var query = @"SELECT COUNT(*) from Categories where CategoryStatus = 0";
				var result = _connection.ExecuteScalar<int>(query);
				return result;
			}
		}
	}
}
