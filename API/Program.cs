using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add the access controll allow origin
builder.Services.AddCors();
// The life cycle of dbcontext is scoped by default
builder.Services.AddDbContext<StoreContext>(opt =>
{
    // Read configuration from appsettings.Development.json in the Properties folder
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));

}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the Cors policy
app.UseCors(opt => 
{
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
}
);
app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
    context.Database.Migrate();
    DbInitializer.Initialize(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "A problem occurred during migration");

}

app.Run();
