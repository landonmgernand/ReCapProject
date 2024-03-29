﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            //<--------------------------------------------------------------------------------------------------->                              
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            //<--------------------------------------------------------------------------------------------------->                              
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            //<--------------------------------------------------------------------------------------------------->                              
            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();
            //<--------------------------------------------------------------------------------------------------->                              
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            //<--------------------------------------------------------------------------------------------------->
            builder.RegisterType<CreditCardManager>().As<ICreditCardService>().SingleInstance();
            builder.RegisterType<EfCreditCardDal>().As<ICreditCardDal>().SingleInstance();
            //<--------------------------------------------------------------------------------------------------->    
            builder.RegisterType<CreditCardTypeManager>().As<ICreditCardTypeService>().SingleInstance();
            builder.RegisterType<EfCreditCardTypeDal>().As<ICreditCardTypeDal>().SingleInstance();
            //<--------------------------------------------------------------------------------------------------->
            builder.RegisterType<UserCreditCardManager>().As<IUserCreditCardService>().SingleInstance();
            builder.RegisterType<EfUserCreditCardDal>().As<IUserCreditCardDal>().SingleInstance();
            //<--------------------------------------------------------------------------------------------------->                              
            builder.RegisterType<IndividualCustomerManager>().As<IIndividualCustomerService>().SingleInstance();
            builder.RegisterType<EfIndividualCustomerDal>().As<IIndividualCustomerDal>().SingleInstance();
            //<--------------------------------------------------------------------------------------------------->
            builder.RegisterType<FakePaymentManager>().As<IPaymentService>().SingleInstance();
            //<--------------------------------------------------------------------------------------------------->
            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            //<--------------------------------------------------------------------------------------------------->                              
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            //<--------------------------------------------------------------------------------------------------->                              
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            //<--------------------------------------------------------------------------------------------------->                              
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
