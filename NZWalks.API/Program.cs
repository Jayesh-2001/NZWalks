using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;

var builder = WebApplication.CreateBuilder(args);

//IN THIS FILE WE ADD DEPENDENCIES TO OUR APPLICATION WHICH WE USE AT LATER POINT IN OUR APPLICATION (DEPENDENCY INJECTION)
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NZWalksDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//Middleware is a software which is assembled in the pipeline of an application to handle requests and responses.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// appsetting.json file is used to store the congiguration for our application, it contains log-levels, database connection string, etc
// Swagger is a popular tool for documenting api and testing the api.

// DbContext class is a class that represents a session with database and provides a set of api for performing database operations.
// DbContext class is reponsibles for maintaining connection with database, tracking changes, performing database operations.

// Dependency Injection is a design pattern to increase maintainability, testability by reducing coupling between the components.
