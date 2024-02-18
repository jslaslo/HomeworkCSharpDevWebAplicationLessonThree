
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Market.Abstractions;
using Market.Context;
using Market.GraphQL;
using Market.Mappers;
using Market.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Market;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<MarketContext>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        builder.Services.AddSingleton<IProductService, ProductService>().AddGraphQLServer().AddQueryType<QueryMarket>().AddMutationType<Mutation>();
        builder.Services.AddSingleton<ICategoryService, CategoryService>();
        builder.Services.AddSingleton<IStoreService, StoreService>();

        builder.Services.AddAutoMapper(typeof(MappingProfile));
        /* builder.Host.ConfigureContainer<ContainerBuilder>(c => c
         .RegisterType<ProductService>()
         .As<IProductService>());*/

        builder.Services.AddMemoryCache(m => m.TrackStatistics = true);

        var app = builder.Build();
        app.MapGraphQL();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

