using Microsoft.EntityFrameworkCore;
using ModernTramApi.Clients;
using ModernTramApi.Db;
using ModernTramApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

// Регистрация Client как Scoped
builder.Services.AddScoped<PassengerClient>();
builder.Services.AddScoped<AdminClient>();
builder.Services.AddScoped<TicketClient>();
builder.Services.AddScoped<IncidentClient>();
builder.Services.AddScoped<ScheduleClient>();
builder.Services.AddScoped<TramClient>();
builder.Services.AddScoped<OperatorClient>();
builder.Services.AddScoped<StaffClient>();
builder.Services.AddScoped<MaintenanceLogClient>();

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
