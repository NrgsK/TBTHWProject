using Autofac;
using Autofac.Extensions.DependencyInjection;
using Bussiness.Abstract;
using Bussiness.Concrete;
using Bussiness.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //Autofac*, Ninject, CastWindsor, StructureMap, LightInject, DryInject --> IoC Container
        //AOP
        //Postsharp 
        builder.Services.AddControllers();
        //builder.Services.AddSingleton<IProductService, ProductManager>();
        //AddSingleton - arkaplanda referans oluþturuyor
        //builder.Services.AddSingleton<IProductDal,EfProductDal>();
        //Bu konfigürasyonu api de yapmak doðru bir kullaným deðil - Autofac
        //CreateHostBuilder(args).Build().Run();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        // Configure the container with Autofac
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(ConfigureContainer);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule(new AutofacBusinessModule());
    }

}

