using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class ProductValidator : AbstractValidator<Product>
	{
		//uygulama calisirken eger product tipi yollanırsa önce bu kontrollerden gecer eger uygunsa eklenir.
		public ProductValidator()
		{
			RuleFor(p => p.ProductName).NotEmpty(); //productname bos olamaz
			RuleFor(p => p.ProductName).MinimumLength(2); //uzunlugu 2 den büyük olmalidir
			RuleFor(p => p.UnitPrice).NotEmpty();//unit price bos olamaz
			RuleFor(p => p.UnitPrice).GreaterThan(0);//0dan büyük olmalidir
			RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 1).WithMessage("Fiyat gecersiz");//kategoriid 1 iken unitprice 10dan büyük olmali
			RuleFor(p => p.ProductName).Must(StartWithA);//a ile baslamali
		}

		private bool StartWithA(string arg)
		{
			return arg.StartsWith("A");
		}
	}
}
