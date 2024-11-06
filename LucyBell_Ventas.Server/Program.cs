using Microsoft.EntityFrameworkCore;
using LucyBell_Ventas.BD.Data;
using System.Text.Json.Serialization;
using LucyBell_Ventas.Server.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));
builder.Services.AddRazorPages();


builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();
builder.Services.AddScoped<IDetalleVentaRepositorio, DetalleVentaRepositorio>();
builder.Services.AddScoped<IMedioVentaRepositorio, MedioVentaRepositorio>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();


app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");


app.Run();