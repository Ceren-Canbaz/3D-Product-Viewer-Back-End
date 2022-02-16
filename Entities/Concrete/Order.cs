using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	//veritabanı nersnesi oldugu icin IEntityi implemente ediyoruz
	public class Order:IEntity
	{
		//veritabanindaki tip ve isimle birebir ayni olmali.
		public int OrderId { get; set; }
		public string CustomerId { get; set; }
		public int EmployeeId { get; set; }
		public DateTime OrderDate { get; set; }
		public string ShipCity { get; set; }
	}
}
