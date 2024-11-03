using Hangfire;
using HangfireBasicAuthenticationFilter;
using MoodVerse.Utility.Emails;
using MoodVerse.Utility.Emails.Interface;
using Microsoft.EntityFrameworkCore;
using MoodVerse.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHangfire((sp, config) =>
{
    var connectionString = sp.GetRequiredService<IConfiguration>().GetConnectionString("DbConnection");
    config.UseSqlServerStorage(connectionString);
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DbConnection"),
        sqlServerOptions => {
            sqlServerOptions.MigrationsAssembly("MoodVerse.Repository");
            sqlServerOptions.CommandTimeout(3000);
        });
});

builder.Services.AddHangfireServer();

builder.Services.AddScoped<IEmailDispatcher, EmailDispatcher>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] {
      new HangfireCustomBasicAuthenticationFilter {
        User = "MoodVerseHangfire",
        Pass = "54N$E9o5YA0x"
      }
    }
});

app.Run();
