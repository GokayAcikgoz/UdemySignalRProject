using SignalR.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.UnitOfWork
{
    public class UowDal : IUoWDal
    {
        private readonly SignalRContext _signalRContext;

        public UowDal(SignalRContext signalRContext)
        {
            _signalRContext = signalRContext;
        }

        public void Save()
        {
            _signalRContext.SaveChanges();
        }
    }
}
