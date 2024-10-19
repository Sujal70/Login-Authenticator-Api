using ConfigReader;
using ConfigReader.Entities;
using DataHelper.Entities.EnumFields;
using DataHelper.HelperClasses;
using LT.Api.Controllers.Common;
using LT.Api.Core_DI;
using LT.Core;
using LT.Core.BaseEntities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

AppSettings.AppConfig = AppConfiguration.ApplyConfiguration(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        },
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });

    setup.SwaggerDoc("v1", new OpenApiInfo { Title = "LT Api", Version = "v1" });
});
builder.Services.AddScoped<Message>();
builder.Services.AddSingleton(AppSettings.AppConfig);
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContextPool<CPortalContext>(options =>
    options.UseSqlServer(AppSettings.AppConfig.DBConnectionString, sqloptions =>
    {
        sqloptions.CommandTimeout((int)TimeoutValues.ThreeMinutes);
    }));
UserConfiguration.ConnectionBuilder = AppSettings.AppConfig.DBConnectionString;
builder.Services.AddBALDependencies();
builder.Services.AddDACDependencies();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

if (app.Environment.IsDevelopment() || Convert.ToBoolean(builder.Configuration["IsSwaggerUIEnabled"]))
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.DocExpansion(DocExpansion.None));
    app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true));
}
else
{
    app.UseCors(x => x.SetIsOriginAllowedToAllowWildcardSubdomains()
    .WithOrigins(AppSettings.AppConfig.CorsURL)
    .AllowAnyHeader()
    .AllowAnyMethod());
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.RunAsync();
