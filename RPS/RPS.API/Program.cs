using RPS.API.RouteConstraints;
using RPS.Application;
using RPS.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// logger
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options =>
    options.ConstraintMap.Add("rpsType", typeof(RPSTypeConstraint)));

//inject repositories
builder.Services.AddInfrastructure();
//inject application
builder.Services.AddApplication();

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", options =>
{
    options
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(host => true);
}));

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
