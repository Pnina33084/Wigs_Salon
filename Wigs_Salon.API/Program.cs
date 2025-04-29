using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wigs_Salon.DAL.Models;
using Wigs_Salon.DAL.Services;

var builder = WebApplication.CreateBuilder(args);

// ����� ������� ��������� �-DI (Dependency Injection)
builder.Services.AddControllers();

// ����� ������ �-DAL
builder.Services.AddScoped<CustomerDal>();
builder.Services.AddScoped<EmployeeDal>();
builder.Services.AddScoped<AppointmentDal>();
builder.Services.AddScoped<ServiceDal>();

// ����� ���� ������
builder.Services.AddDbContext<DB_Manager>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ����������� �� API
var app = builder.Build();

// ������������ �� ���������
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// ���� �� �����������
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
