using Microsoft.EntityFrameworkCore;
using NIFTWebApp.Data;
using NIFTWebApp.Modules.BiddingModule.Interfaces;
using NIFTWebApp.Modules.BiddingModule.Services;
using NIFTWebApp.Modules.CarouselModule.Interfaces;
using NIFTWebApp.Modules.CarouselModule.Services;
using NIFTWebApp.Modules.ProductModule.Interfaces;
using NIFTWebApp.Modules.ProductModule.Services;
using NIFTWebApp.Modules.UserModule.Interfaces;
using NIFTWebApp.Modules.UserModule.Services;
using NIFTWebApp.Modules.VendorModule.Interfaces;
using NIFTWebApp.Modules.VendorModule.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// For all Profile mappings
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Product
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Bidding
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<IBidRepository, BidRepository>();

// User
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Vendor
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();

//CarouselCard
builder.Services.AddScoped<ICarouselCardRepository, CarouselCardRepository>();
builder.Services.AddScoped<ICarouselCardService, CarouselCardService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});




builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
