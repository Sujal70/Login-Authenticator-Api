using ConfigReader;
using ConfigReader.Entities;
using DataHelper.Entities.EnumFields;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Application.LoginAttemptServicr;
using ITAM.Core.Profiles;
using ITAM.Data.SPData.Interfaces;
using ITAM.Data.SPData.Repositories;
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

    setup.SwaggerDoc("v1", new OpenApiInfo { Title = "ITAM Api", Version = "v1" });
});
builder.Services.AddScoped<Message>();
builder.Services.AddSingleton(AppSettings.AppConfig);
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContextPool<InboxContext>(options =>
    options.UseSqlServer("server=172.16.1.90;uid=TTA2024;pwd=Rizvi@2024;database=RizviTTA;Min Pool Size=5;Max Pool Size=500;TrustServerCertificate=True;MultipleActiveResultSets=True;Command timeout=500", sqloptions => {
        sqloptions.CommandTimeout((int)TimeoutValues.ThreeMinutes);
    }));
UserConfiguration.ConnectionBuilder = AppSettings.AppConfig.DBConnectionString;
builder.Services.AddBALDependencies();
builder.Services.AddDACDependencies();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(AssetDetailProfile));

builder.Services.AddScoped<IAssetMasterSPRepo, AssetMasterSPRepo>();
builder.Services.AddScoped<IAssetMasterService, AssetMasterService>();
builder.Services.AddSingleton<IloginAttemptService, loginAttemptService>();

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
