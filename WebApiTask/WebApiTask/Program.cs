using Microsoft.EntityFrameworkCore;
using WebApiTask.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200") // 🟢 Permite Angular
                        .AllowAnyMethod()  // Permite cualquier método (GET, POST, PUT, DELETE)
                        .AllowAnyHeader()); // Permite cualquier header
});


// Add services to the container.

//Crear una variable para la cadena de conexion
var connectionString = builder.Configuration.GetConnectionString("Connection");

//Registrar servicio para la conexion 
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

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
app.UseCors("AllowAngular");
app.UseAuthorization();

app.MapControllers();

app.Run();
