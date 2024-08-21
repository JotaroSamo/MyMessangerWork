using Microsoft.EntityFrameworkCore;
using MyMessagerWork.Application.Service;
using MyMessagerWork.Core.Abstract;
using MyMessagerWork.DataAcess;
using MyMessagerWork.DataAcess.Mapper;
using MyMessagerWork.DataAcess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MessagerDbContext>(options =>
              options.UseSqlite(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperCoreDB));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRepositoryUser, UserRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
