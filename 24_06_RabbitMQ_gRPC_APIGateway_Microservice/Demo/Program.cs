using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Demo.Application.Commands;
using Demo.Application.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DemoWebApiContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<StudentCommands>();
builder.Services.AddScoped<StudentQueries>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();