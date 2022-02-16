using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class Product:IEntity
	{

		//classın defaulttaki hali internaldır. bu sadece o projenin içindeki üyelerin classa ulasabilmesini sağlar.
		//classı public yaptık ->bu classa diğer katmanlar da ulaşabilsin anlamına gelmektedir.

		public int ProductId { get; set; }
		public int CategoryId { get; set; }
		public string ProductName { get; set; }
		public short UnitsInStock { get; set; }
		public decimal UnitPrice { get; set; }

	}
}
