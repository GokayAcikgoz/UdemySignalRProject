using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Dapper.Abstract
{
	public interface IOrderDapperRepository
	{
		int TotalOrderCount();
		int ActiveOrderCount();
		decimal LastOrderPrice();
		decimal TodayTotalPrice();
	}
}
