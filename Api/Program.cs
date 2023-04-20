using Infraestructure;
using Application;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Application.Service.Abstraction;
using Application.Service.Implementation.Command;
using Api.GraphQLQueries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///<summary>
/// GraphQL Setup.
/// </summary>
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

///<summary>
/// Layers configuration.
/// </summary>
    builder.Services
        .InitInfrastructure()
        .InitApplication(builder.Configuration);

// Database SqlServer connetion.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DogiConnection"));
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapGraphQL("/graphql");


app.Run();
