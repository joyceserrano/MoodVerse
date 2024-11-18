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
using MoodVerse.Utility.Emails.Model;
using MoodVerse.Utility.JWT.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//builder.Services.AddCors(options =>
//         options.AddDefaultPolicy(
//             b =>
//             {
//                 b
//                 .AllowAnyMethod()
//                 .AllowAnyHeader()
//                 .AllowCredentials()
//                 .WithExposedHeaders("WWW-Authenticate")
//                 .WithOrigins(builder.Configuration.GetValue<string>("BaseUrl"));
//             }
//         ));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHangfire((sp, config) =>
{
    var connectionString = sp.GetRequiredService<IConfiguration>().GetConnectionString("DbConnection");
    config.UseSqlServerStorage(connectionString);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
builder.Services.AddScoped<ILookupRepository, LookupRepository>();

builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<ILookupService, LookupService>();

builder.Services.AddScoped<IEmailDispatcher, EmailDispatcher>();

builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

//app.UseCors();
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
