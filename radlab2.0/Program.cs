using Microsoft.EntityFrameworkCore;
using radlab2_0.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add DbContexts for Todo and Advertisement APIs
builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseInMemoryDatabase("TodoList"));  // In-memory database for Todo API

builder.Services.AddDbContext<AdDbContext>(options =>
    options.UseInMemoryDatabase("AdList"));  // In-memory database for Advertisement API

// Add Swagger for API documentation and testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();  // Maps your API controllers to routes

app.Run();