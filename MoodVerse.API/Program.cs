using Hangfire;
using HangfireBasicAuthenticationFilter;
using Microsoft.EntityFrameworkCore;
using MoodVerse.Repository;
using MoodVerse.Repository.Implementation;
using MoodVerse.Repository.Interface;
using MoodVerse.Service.Implementation;
using MoodVerse.Service.Interface;
using MoodVerse.Utility.Emails;
using MoodVerse.Utility.Emails.Interface;


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

builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IArtistService, ArtistService>();

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
