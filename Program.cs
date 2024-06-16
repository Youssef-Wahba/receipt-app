using Microsoft.EntityFrameworkCore;
using receipt_app;
using AutoMapper;
using receipt_app.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using receipt_app.Service;

var builder = WebApplication.CreateBuilder(args);

// MYSQL db connection
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Item service
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<ReceiptService>();
// auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// configure controllers
builder.Services.AddControllers();

// auto mapper configuration 

// global validation handler
builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState.Values.SelectMany(v => v.Errors)
                                                .Select(e => e.ErrorMessage)
                                                .ToList();
            return new BadRequestObjectResult(new { errors });
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Receipt App",
        Version = "v1",
        Description = "API documentation for simple Receipt App",
        Contact = new OpenApiContact
        {
            Name = "Youssef Wahba",
            Email = "y.husseinwahba@gmail.com",
            Url = new Uri("https://github.com/Youssef-Wahba"),
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MigrateDb();

app.Run();
