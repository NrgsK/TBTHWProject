﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Bussiness.Abstract;
using Bussiness.CCS;
using Bussiness.Concrete;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance(); //WebApi yerine burada kullanmamız bağlılığı azarltır.
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();


            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance(); //WebApi yerine burada kullanmamız bağlılığı azarltır.
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            //builder.RegisterType<IHttpContextAccessor>().As<IHttpContextAccessor>();

            var assembly=System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector=new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
