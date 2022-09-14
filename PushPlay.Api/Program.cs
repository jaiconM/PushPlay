using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PushPlay.Api.Filters;
using PushPlay.Application.Config;
using PushPlay.Data.Config;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidIssuer = builder.Configuration["Issuer"],
                        ValidAudience = builder.Configuration["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSecret"]))
                    };
                });

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilterAtribute>();
});
builder.Services
    .RegisterApplication()
    .RegisterRepository(builder.Configuration.GetConnectionString("PushPlayDBConn"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
