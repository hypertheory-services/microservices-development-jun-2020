using CoursesApi.Adapters;
using CoursesApi.Domain;

using HypertheoryApiUtils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoConnectionOptions>(
    builder.Configuration.GetSection(MongoConnectionOptions.SectionName));

builder.Services.AddSingleton<CoursesMongoDbAdapter>();
builder.Services.AddScoped<CoursesData>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
