using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	//burada productdal dısında interface tanimlama 
	public class ProductManager : IProductService
	{
		IProductDal _productDal;
		ICategoryService _categoryService;
		public ProductManager(IProductDal productDal,ICategoryService categoryService)
		{
			_productDal = productDal;
			_categoryService = categoryService;

		}

		//Attribute //bu aspecti autofac devreye sokar.
		[ValidationAspect(typeof(ProductValidator))]//parametreyi okuyup uygun validatioon islemini bulup islemi yapacak.
		public IResult Add(Product product)
		{
			IResult result =BusinessRules.Run(CheckIfProductCountofCategoryCorrect(product.CategoryId), CheckIfProductNameExist(product.ProductName),CheckIfCategoryLimitExceded());
			if(result!= null)
			{
				return result;
			}
			_productDal.Add(product);
			return new SuccessResult(Messages.ProductAdded);
		}

		public IDataResult<Product> GetById(int id)
		{
			if (DateTime.Now.Hour == 22)
			{
				return new ErrorDataResult<Product>(Messages.Maintenance);
			}
			return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
		}

		public IDataResult<List<Product>> GetAll()
		{
			if (DateTime.Now.Hour == 10)
			{
				return new ErrorDataResult<List<Product>>(Messages.Maintenance);
			}
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
		}

		public IDataResult<List<Product>> GetAllByCategory(int id)
		{
			if (DateTime.Now.Hour == 22)
			{
				return new ErrorDataResult<List<Product>>(Messages.Maintenance);
			}
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), Messages.ProductsListed);
		}

		public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
		}

		public IDataResult<List<ProductDetailDto>> GetProductDetails()
		{
			if (DateTime.Now.Hour == 21)
			{
				return new ErrorDataResult<List<ProductDetailDto>>(Messages.ProductNameInvalid);
			}
			return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
		}

		public IResult Update(Product product)
		{
			throw new NotImplementedException();
		}
		//bu method yalnızca bu class icinde kullanilacak
		private IResult CheckIfProductCountofCategoryCorrect(int categoryId)
		{
			var result = _productDal.GetAll(p=>p.CategoryId==categoryId).Count;
			if (result >= 10)
			{
				return new ErrorResult(Messages.ProductsCategoryCountError);
			}
			return new SuccessResult();
		}
		private IResult CheckIfProductNameExist(string productName)
		{
			//any bool döndürür
			var result = _productDal.GetAll(p => p.ProductName==productName).Any();
			if (result)
			{
				return new ErrorResult(Messages.ProductNameAlreadyExist);
			}
			return new SuccessResult();
		}
		private IResult CheckIfCategoryLimitExceded()
		{
			var result = _categoryService.GetAll();
			if (result.Data.Count > 15)
			{
				return new ErrorResult("Category Limit Exceded");
			}
			return new SuccessResult();
		}
	}
}
