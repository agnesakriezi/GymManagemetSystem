using GymManagementSystem.Data;
using GymManagementSystem.Repositories;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
builder.Services.AddScoped<IMembershipService, MembershipService>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();

builder.Services.AddScoped<IBillingRepository, BillingRepository>();
builder.Services.AddScoped<IBillingService, BillingService>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Configure JWT authentication
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
