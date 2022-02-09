using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			//test ortamı
			ProductManager produtcManager = new ProductManager(new InMemoryProductDal());
			foreach (var product in produtcManager.GetAll())
			{
				Console.WriteLine(product.ProductName);
			}
		}
	}
}
