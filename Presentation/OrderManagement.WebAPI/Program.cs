using System.Net;
using System.Text.Json.Serialization;
using OrderManagement.Application;
using OrderManagement.Persistance;
using OrderManagement.WebAPI.Extensions;
using TechBuddy.Middlewares.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.ConfigureExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();
app.AddTBExceptionHandlingMiddleware(opt =>
{
    opt.ExceptionHandlerAction = async (httpContext, ex) =>
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        await httpContext.Response.WriteAsync(ex.Message);
    };
});

app.MapControllers();

app.Run();
