using Microsoft.EntityFrameworkCore;
using Wigs_Salon.BL.Interfaces;
using Wigs_Salon.BL.Services;
using Wigs_Salon.DAL.API;
using Wigs_Salon.DAL.Models;
using Wigs_Salon.DAL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Database context
builder.Services.AddDbContext<DB_Manager>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

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
