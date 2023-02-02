using Google.Protobuf.WellKnownTypes;
using Kampai.Licors.Domain.Repositories;
using Kampai.Licors.Domain.Services;
using Kampai.Licors.Mapping;
using Kampai.Licors.Persistence.Repositories;
using Kampai.Licors.Services;
using Kampai.Shared.Domain.Repositories;
using Kampai.Shared.Persistence.Context;
using Kampai.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Depency Injection Configuration

builder.Services.AddScoped<ILicorRepository, LicorRepository>();
builder.Services.AddScoped<ILicorService, LicorService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(
    typeof(ModelToResourceLicorProfile),
    typeof(ResourceToModelLicorProfile));
        
var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();