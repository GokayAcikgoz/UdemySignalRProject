using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.MenuTableDto
{
	public class CreateMenuTableDto
	{
        public CreateMenuTableDto()
        {
            Status = false;
        }
        public string Name { get; set; }
		public bool Status { get; set; }
	}
}
