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
			foreach (var product in produtcManager.GetAll())
			{
				Console.WriteLine(product.ProductName);
			}
		}
	}
}
