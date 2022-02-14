using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			//test ortamı
			ProductManager produtcManager = new ProductManager(new EfProductDal());
			foreach (var product in produtcManager.GetAllByCategory(2))
			{
				Console.WriteLine(product.ProductName);
			}
			ProductManager productManager2 = new ProductManager(new EfProductDal());
			string name=productManager2.Get(2).ProductName;
			Console.WriteLine("idsi 2 olan ürünün ismi: "+name);
			
		}
	}
}
