using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.BAL.Interfaces;
using TaskManagementSystem.BAL.Services;
using TaskManagementSystem.DAL;
using TaskManagementSystem.DAL.Interface;
using TaskManagementSystem.DAL.Interfaces;
using TaskManagementSystem.DAL.Repository;
using TaskManagementSystem.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<ITaskDetailsRepository, TaskDetailsRepository>();
builder.Services.AddTransient<IUserDetailRepository, UserDetailRepository>();
builder.Services.AddTransient<ITaskDetailService, TaskDetailService>();
builder.Services.AddTransient<IUserDetailService, UserDetailService>();
builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddAutoMapper(typeof(MapperConfig));

var jwtSettings = builder.Configuration.GetSection("JWT");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
 {
     options.Events = new JwtBearerEvents
     {
         OnMessageReceived = context =>
         {
             if (context.Request.Cookies.ContainsKey("Authorization"))
             {
                 var token = context.Request.Cookies["Authorization"];
                 var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
                 logger.LogInformation($"Token from cookie: {token}");
                 context.Token = token.Replace("Bearer ", "");
             }
             return Task.CompletedTask;
         }
     };
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtSettings["ValidIssuer"],
         ValidAudience = jwtSettings["ValidAudience"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]))
     };
 });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
