using Microsoft.EntityFrameworkCore;
using MuzluCacýkAPI;
using MuzluCacýkAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

/* 
 Project Title: Learning xUnit Testing in .NET/C#

Description:
This project was created as a hands-on learning experience for xUnit testing in the .NET/C# environment.
The solution consists of a basic web API that intentionally returns nothing, serving as a playground for understanding and implementing xUnit tests.

Key Features:
The primary goal of this project is to provide a practical platform for improving skills in xUnit testing within the .NET framework.

How It Looks:
The project comprises a straightforward web API with minimal functionality, intentionally kept simple to focus on the nuances of writing effective xUnit tests.
The test suite covers various scenarios, showcasing the application of xUnit concepts such as Arranging, Acting, and Assertions.

Usage:
Feel free to explore the codebase and run the tests. Contributions, feedback, and improvements are always welcome!

Getting Started:
Clone the repository to your local machine.
Launch the solution within the.NET development environment of your choice. For this, I recommend Visual Studio.
Explore the project structure and dive into the Tests folder to see xUnit tests.
Run the tests to observe their behavior.

Contributions:
If you have insights, improvements, or additional test cases to contribute, please feel free to submit a pull request.
Let's learn and grow together!
 */