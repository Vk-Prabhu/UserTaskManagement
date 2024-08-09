using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.API;
using TaskManagementSystem.BAL.Interfaces;
using TaskManagementSystem.BAL.Services;
using TaskManagementSystem.DAL;
using TaskManagementSystem.DAL.Interface;
using TaskManagementSystem.DAL.Interfaces;
using TaskManagementSystem.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")),
    ServiceLifetime.Transient
   );

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<ITaskDetailsRepository, TaskDetailsRepository>();
builder.Services.AddTransient<IUserDetailRepository, UserDetailRepository>();
builder.Services.AddTransient<ITaskDetailService, TaskDetailService>();
builder.Services.AddTransient<IUserDetailService, UserDetailService>();
builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddAutoMapper(typeof(MapperConfig));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
