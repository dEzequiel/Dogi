using Api.GraphQL.GraphQLTypes;
using Api.GraphQL.Types;
using Application;
using Infraestructure;
using Infraestructure.Authentication;
using Infraestructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///<summary>
/// Layers configuration.
/// </summary>
builder.Services
    .InitInfrastructure()
    .InitApplication(builder.Configuration);


builder.Services.AddAuthorization();

builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

//////<summary>
/// GraphQL Setup.
/// </summary>
builder.Services.AddHttpContextAccessor();

///<summary>
/// GraphQL Setup.
/// </summary>
builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .AddApiTypes()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .RegisterDbContext<ApplicationDbContext>()
    .AddQueryType<QueryType>()
    .AddMutationType<MutationType>();

//.AddErrorFilter<ErrorFilter>();

// Database SqlServer connetion.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseLazyLoadingProxies();
    options.UseSqlServer(builder.Configuration.GetConnectionString("DogiConnection"))
        //options.UseSqlServer(builder.Configuration["Azure:ConnectionString"])
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
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

/// <summary>
/// Call JWT Token validator for requests.
/// <summary>
//app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
    endpoints.MapGraphQL("/auth", schemaName: "auth");
});


app.Run();