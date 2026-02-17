// PdBL commit test for fix
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using RoomBookingBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Tambahkan koneksi MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    ));

// Tambahkan controller
builder.Services.AddControllers();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "RoomBooking API",
        Version = "v1",
        Description = "API untuk Room Booking System"
    });
});

// Tambahkan CORS untuk frontend React
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RoomBooking API v1");
        c.RoutePrefix = "swagger"; // UI di /swagger
    });
}

// ⚠️ Matikan HTTPS redirect dulu (karena backend listen di http://localhost:5110)
// app.UseHttpsRedirection();

app.UseRouting();

// Aktifkan CORS
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();