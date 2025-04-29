using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wigs_Salon.DAL.Models;
using Wigs_Salon.DAL.Services;

var builder = WebApplication.CreateBuilder(args);

// הוספת שירותים לקונטיינר ה-DI (Dependency Injection)
builder.Services.AddControllers();

// הזרקת שירותי ה-DAL
builder.Services.AddScoped<CustomerDal>();
builder.Services.AddScoped<EmployeeDal>();
builder.Services.AddScoped<AppointmentDal>();
builder.Services.AddScoped<ServiceDal>();

// קישור למסד נתונים
builder.Services.AddDbContext<DB_Manager>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// קונפיגורציה של API
var app = builder.Build();

// הקונפיגורציה של האפליקציה
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// שגרה של הקונטרולרים
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
