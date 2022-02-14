using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryProductDal : IProductDal
	{
		//newlendiği anda calısacak olan yer
		//sqlden alıyormus gibi simule ettik

		List<Product> _products;
		public InMemoryProductDal()
		{

			_products = new List<Product> {
				new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=10},
				new Product{ProductId=2,CategoryId=2,ProductName="Kamera",UnitPrice=500,UnitsInStock=20},
				new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=2000,UnitsInStock=3},
				new Product{ProductId=4,CategoryId=2,ProductName="Televizyon",UnitPrice=5000,UnitsInStock=2},
				new Product{ProductId=5,CategoryId=1,ProductName="Tabak",UnitPrice=10,UnitsInStock=65}
			};
		}
		public void Add(Product product)
		{
			_products.Add(product);
		}

		public void Delete(Product product)
		{
			Product productToDelete = null;
			//foreach (var p in _products)
			//{
			//	if (product.ProductId == p.ProductId)
			//	{
			//		productToDelete = p;
			//	}
			//}

			//LINQ- Language Integrated Query
			//SingleOrDefault listenin içindeki elemanları dolaşacaktır
			//alternative method with LINQ
			productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);

			_products.Remove(productToDelete);
		}

		public Product Get(Expression<Func<Product, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public List<Product> GetAll()
		{
			return _products;
		}

		public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		//urunleri kategoriye göre filtreleme
		public List<Product> GetAllByCategory(int categoryId)
		{
			//where methodu içindeki şarta uyan elemanları yeni bir liste haline getirip döndürür
			return _products.Where(p => p.CategoryId == categoryId).ToList();
		}

		public void Update(Product product)
		{
			//Gelen urunidsine göre sahip olunan listedeki ürünü bul
			Product productToUpdate = productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
			productToUpdate.ProductName = product.ProductName;
			productToUpdate.CategoryId = product.CategoryId;
			productToUpdate.UnitPrice = product.UnitPrice;
			productToUpdate.UnitsInStock = product.UnitsInStock;


		}
	}
}
