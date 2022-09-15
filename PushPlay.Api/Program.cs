using Microsoft.EntityFrameworkCore;
using PushPlay.Api.Config;
using PushPlay.Api.Filters;
using PushPlay.Application.Config;
using PushPlay.Data.Config;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureAutenticacao(builder);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilterAtribute>();
});

builder.Services.RegisterApplication();

builder.Services.RegisterRepository(builder.Configuration.GetConnectionString("PushPlayDBConn"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
