using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using MyLocalPages.API;
using MyLocalPages.Domain.DBContext;
using MyLocalPages.Services.BusinessDirectory;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/mylocalpagesinfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyLocalPagesContext>(
    dbContextOptions => dbContextOptions.UseSqlite(
        builder.Configuration["ConnectionStrings:MyLocalPagesDBConnectionString"], b => b.MigrationsAssembly("MyLocalPages.Domain")));

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Services.AddSingleton<MyLocalPagesDataStore>();
builder.Services.AddScoped<IBusinessDirectoryService, BusinessDirectoryService>();

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
