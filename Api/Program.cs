using Api.Extensions;
using Api.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddJwtBearer(builder.Configuration);

builder.Services.AddScoped<IRepository, FileRepository>();

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
