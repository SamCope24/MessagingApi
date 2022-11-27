using Api.Extensions;
using Api.Persistence.EntityFramework;
using Api.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddJwtBearer(builder.Configuration);

if (builder.Configuration["Repository:Type"] == "DB")
{
    builder.Services.AddScoped<IRepository, PostgresRepository>();
    builder.Services.AddDbContext<MessagingDbContext>();
}
else
{
    builder.Services.AddScoped<IRepository, FileRepository>();
}

var app = builder.Build();

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

public partial class Program {}
