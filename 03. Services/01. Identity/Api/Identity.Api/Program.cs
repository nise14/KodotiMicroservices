using System.Reflection;
using Common.Logging;
using HealthChecks.UI.Client;
using Identity.Domain;
using Identity.Persistence.Database;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// HttpContextAccessor
builder.Services.AddHttpContextAccessor();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsHistoryTable("__EFMigrationHistory", "Identity")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy())
    .AddDbContextCheck<ApplicationDbContext>();

builder.Services.AddHealthChecksUI().AddInMemoryStorage();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
       {
           options.Password.RequireDigit = false;
           options.Password.RequireLowercase = false;
           options.Password.RequireNonAlphanumeric = false;
           options.Password.RequireUppercase = false;
           options.Password.RequiredLength = 6;
           options.Password.RequiredUniqueChars = 1;
       });

builder.Services.AddMediatR(Assembly.Load("Identity.Service.EventHandlers"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
loggerFactory.AddSyslog(
    builder.Configuration.GetValue<string>("Papertrail:host"),
    builder.Configuration.GetValue<int>("Papertrail:port")
);

app.UseAuthorization();
app.UseAuthentication();
app.MapHealthChecks("/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});


app.UseHealthChecksUI(config =>
{
    config.UIPath = "/health-ui";
});

app.MapControllers();

app.Run();
