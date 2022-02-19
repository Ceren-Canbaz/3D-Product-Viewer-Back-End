using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public IResult Add(Product product)
		{
			if (product.ProductName.Length < 2)
			{
				return new ErrorResult("Ürün ismi en az iki karakter olmalıdır");
			}
			_productDal.Add(product);

			return new SuccessResult("Ürün Eklendi");
		}

		public Product GetById(int id)
		{
			return _productDal.Get(p => p.ProductId==id);
		}

		public List<Product> GetAll()
		{
			return _productDal.GetAll();
		}

		public List<Product> GetAllByCategory(int id)
		{
			return _productDal.GetAll(p=>p.CategoryId==id);
		}

		public List<Product> GetByUnitPrice(decimal min, decimal max)
		{
			return _productDal.GetAll(p => p.UnitPrice>=min && p.UnitPrice<=max);
		}

		public List<ProductDetailDto> GetProductDetails()
		{
			return _productDal.GetProductDetails();
		}

	
	}
}
