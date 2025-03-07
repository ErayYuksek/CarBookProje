 using CarBookProje.Application.Features.CQRS.Handlers.AboutHandler;
using CarBookProje.Application.Features.CQRS.Handlers.BannerHandler;
using CarBookProje.Application.Features.CQRS.Handlers.BrandHandler;
using CarBookProje.Application.Features.CQRS.Handlers.CarHandler;
using CarBookProje.Application.Features.CQRS.Handlers.CategoryHandler;
using CarBookProje.Application.Features.CQRS.Handlers.ContactHandler;
using CarBookProje.Application.Features.CQRS.Queries.AboutQueries;
using CarBookProje.Application.Features.RepositoryPattern;
using CarBookProje.Application.Interfaces;
using CarBookProje.Application.Interfaces.BlogInterfaces;
using CarBookProje.Application.Interfaces.CarÝnterfaces;
using CarBookProje.Application.Interfaces.CarPricingInterfaces;
using CarBookProje.Application.Services;
using CarBookProje.Persistence.Context;
using CarBookProje.Persistence.Repositories;
using CarBookProje.Persistence.Repositories.BlogRepository;
using CarBookProje.Persistence.Repositories.CarPricingRepository;
using CarBookProje.Persistence.Repositories.CarRepositories;
using CarBookProje.Persistence.Repositories.CommentRepositories;
using UCarBook.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Context  Class
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));



// Handler Sýnýfýlarý
// About
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

// Banner

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

//  Car

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();

// Category
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
// Contact


builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
//
// Contact


builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
//
builder.Services.AddApplicationService(builder.Configuration);

//////////////////////////////////////////
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
