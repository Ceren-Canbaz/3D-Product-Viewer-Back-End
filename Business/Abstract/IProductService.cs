using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IProductService
	{
		IDataResult<List<Product>> GetAll(); //data ve islem sonucu döndürülecek
		IDataResult<List<Product>> GetAllByCategory(int id);
		IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
		IDataResult<Product> GetById(int id);
		IDataResult<List<ProductDetailDto>> GetProductDetails();
		IResult Add(Product product);
		IResult Update(Product product);
	}
}
