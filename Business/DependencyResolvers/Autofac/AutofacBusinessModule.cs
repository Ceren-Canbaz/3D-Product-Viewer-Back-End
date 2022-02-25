using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule:Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			//IProductService istendginde ProductManager olustur ve referansını ver
			builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
			builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
		}
	}
}
