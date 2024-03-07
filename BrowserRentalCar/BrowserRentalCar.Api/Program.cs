using BrowserRentalCar.Infraestructure;
using BrowserRentalCar.Application;
using BrowserRentalCar.Api.ApiHandlers;
using BrowserRentalCar.Api.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.MapGroup("/api/vehicle").MapVehicle();
app.MapGroup("/api/location").MapLocation();
app.MapGroup("/api/TravelHistoy").MapTravelHistory();

app.Run();


