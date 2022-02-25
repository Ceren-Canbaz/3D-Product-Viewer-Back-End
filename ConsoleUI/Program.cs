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
			//Data Transformation Object
			//test ortamı
			ProductTest();
			//CategoryTest();

		}

		private static void CategoryTest()
		{
			CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
			foreach (var category in categoryManager.GetAll())
			{
				Console.WriteLine(category.CategoryName);
			}
		}

		private static void ProductTest()
		{
			ProductManager produtcManager = new ProductManager(new EfProductDal());
			//foreach (var product in produtcManager.GetAllByCategory(2))
			//{
			//	Console.WriteLine(product.ProductName);
			//}
			//ProductManager productManager2 = new ProductManager(new EfProductDal());
			//string name = productManager2.Get(2).ProductName;
			//Console.WriteLine("idsi 2 olan ürünün ismi: " + name);
			var result = produtcManager.GetProductDetails();

			if (result.Success==true)
			{
				foreach (var product in result.Data)
				{
					Console.WriteLine("Product Name: "+product.ProductName + " Category Name: " + product.CategoryName);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
	
		}
	}
}
