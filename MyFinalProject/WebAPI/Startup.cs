using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Startup
    {
        //public static WebApplication InitializeApp(string[] args)
        //{
        //    var builder = WebApplication.CreateBuilder(args);
        //    ConfigureServices(builder);
        //    var app = builder.Build();
        //    Configure(app);
        //    return app;
        //}

        //public static WebApplication InitializeApp(string[] args)
        //{
        //    var service = WebApplication.CreateBuilder(args);
        //    ConfigureServices(services);
        //    var app = service.Build();
        //    Configure(app);
        //    return app;
        //}

        //public static void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();
        //    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //    services.AddEndpointsApiExplorer();
        //    services.AddSwaggerGen();
            //sen bir Iproductservice görürsen onun karşılığı productmanager
            //builder.Services.AddSingleton<IProductService, ProductManager>();
            //builder.Services.AddSingleton<IProductDal, EfProductDal>();

        }

        //private static void Configure(WebApplication app)
        //{
        //    // Configure the HTTP request pipeline.
        //    if (app.Environment.IsDevelopment())
        //    {
        //        app.UseSwagger();
        //        app.UseSwaggerUI();
        //    }

        //    app.UseHttpsRedirection();

        //    app.UseAuthorization();

        //    app.MapControllers();

        //}

    //public static void Configure(WebApplication app)
    //    {
    //        if (app.Environment.IsDevelopment())
    //        {
    //            app.UseSwagger();
    //            app.UseSwaggerUI();
    //        }

    //        app.UseHttpsRedirection();

    //        app.UseAuthorization();

    //        app.MapControllers();
    //    }
    //}
}
