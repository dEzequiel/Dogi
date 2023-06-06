using System.Security.Claims;
using System.Text;
using Api.GraphQL.ObjectTypes;
using Application;
using Infraestructure;
using Infraestructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var signingKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidIssuer = "local",
            ValidAudience = "local",
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey
        };
});

//////<summary>
/// GraphQL Setup.
/// </summary>
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<ClaimsPrincipal>(s =>
    s.GetService<IHttpContextAccessor>().HttpContext.User);

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

app.MapControllers();

app.UseRouting();


app.UseAuthentication();


app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });


app.Run();