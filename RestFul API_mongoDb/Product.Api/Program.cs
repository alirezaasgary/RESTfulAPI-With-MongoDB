
using Product.API;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//builder.Services.Configure<BookStoreDatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

//builder.Services.AddHealthChecks().admon.(builder.Configuration["DatabaseSettings:ConnectionString"], "MongoDb Health", HealthStatus.Degraded);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ProductDatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
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
