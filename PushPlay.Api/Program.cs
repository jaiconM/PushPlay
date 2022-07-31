using Microsoft.EntityFrameworkCore;
using PushPlay.Api.Filters;
using PushPlay.Application.Config;
using PushPlay.Data.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilterAtribute>();
});
builder.Services
    .RegisterApplication()
    .RegisterRepository(builder.Configuration.GetConnectionString("PushPlayDBConn"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
