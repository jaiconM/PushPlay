using Microsoft.EntityFrameworkCore;
using PushPlay.Application.Config;
using PushPlay.Repository.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
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
