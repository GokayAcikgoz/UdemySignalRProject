using Dapper;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Dapper.Abstract;
using System.Data;


namespace SignalR.DataAccessLayer.Dapper.Concrete
{
	public class ProductDapperManager : IProductDapperRepository
	{
		private readonly IDbConnection _connection;

		public ProductDapperManager(SignalRContext context)
		{
			_connection = context.GetConnection();
		}

		public int ProductCount()
		{
			using (_connection)
			{
				_connection.Open();
				var query = @"SELECT COUNT(*) FROM PRODUCTS";
				var result = _connection.ExecuteScalar<int>(query);
				return result;
			}			
		}

		public int ProductCountByCategoryNameDrink()
		{
			using (_connection)
			{
				_connection.Open();
				var query = @"SELECT COUNT(*) FROM Products AS p
							INNER JOIN Categories AS c ON p.CategoryID = c.CategoryID
							WHERE c.CategoryName = 'İçecek'";
				var result = _connection.ExecuteScalar<int>(query);
				return result;
			}
		}

		public int ProductCountByCategoryNameHamburger()
		{
			using (_connection)
			{
				_connection.Open();
				var query = @"SELECT COUNT(*) FROM Products AS p
							INNER JOIN Categories AS c ON p.CategoryID = c.CategoryID
							WHERE c.CategoryName = 'Hamburger'";
				var result = _connection.ExecuteScalar<int>(query);
				return result;
			}
		}

		public string ProductNameByMaxPrice()
		{
			using (_connection)
			{
				_connection.Open();
				string query = @"SELECT TOP 1 ProductName 
								FROM Products 
								ORDER BY Price DESC";
				var result = _connection.ExecuteScalar<string>(query);
				return result;
			}
		}

		public string ProductNameByMinPrice()
		{
			using (_connection)
			{
				_connection.Open();
				string query = @"SELECT TOP 1 ProductName 
								FROM Products 
								ORDER BY Price ASC";
				var result = _connection.ExecuteScalar<string>(query);
				return result;
			}
		}

		public decimal ProductPriceAvg()
		{
			using (_connection)
			{
				_connection.Open();
				string query = @"SELECT AVG(Price) FROM PRODUCTS";
				var result = _connection.ExecuteScalar<decimal>(query);
				return result;
			}
		}

		public decimal ProductAvgPriceByHamburger()
		{
			using (_connection)
			{
				_connection.Open();
				string query = @"SELECT AVG(Price) FROM PRODUCTS p
								INNER JOIN Categories c 
								on c.CategoryID = p.CategoryID where c.CategoryName = 'Hamburger'";
				var result = _connection.ExecuteScalar<decimal>(query);
				return result;
			}
		}
	}
}
