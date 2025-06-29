using Microsoft.EntityFrameworkCore;
using Wigs_Salon.BL.Interfaces;
using Wigs_Salon.BL.Services;
using Wigs_Salon.DAL.API;
using Wigs_Salon.DAL.Models;
using Wigs_Salon.DAL.Services;

var builder = WebApplication.CreateBuilder(args);

// הוספת DbContext עם חיבור למסד הנתונים
builder.Services.AddDbContext<DB_Manager>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// הוספת CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// DAL
builder.Services.AddScoped<IAppointmentDal, AppointmentDal>();
builder.Services.AddScoped<ICustomerDal, CustomerDal>();
builder.Services.AddScoped<IEmployeeDal, EmployeeDal>();
builder.Services.AddScoped<IServiceDal, ServiceDal>();

// BL
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IServiceService, ServiceService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// הוספת CORS לפני Authorization
app.UseCors();

app.UseAuthorization();
app.MapControllers();
app.Run();
