//using Microsoft.AspNetCore.Builder;
//using WebApplication2.Controller;

//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddScoped<CheckoutController>();
//builder.Services.AddScoped<HelloController>();
//var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Run();
using WebApplication2.Controller;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container
builder.Services.AddControllers();
builder.Services.AddScoped<CheckoutController>();
builder.Services.AddScoped<Checkout>();
// Learn more about configuring Swagger/OpenAPI a https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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