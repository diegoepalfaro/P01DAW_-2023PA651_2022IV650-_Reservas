using Microsoft.EntityFrameworkCore;
using P01DAW__2023PA651_2022IV650__Reservas.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ReservasContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("BibliotecaDbConnection")
            )
);

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
