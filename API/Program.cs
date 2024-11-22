using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);  //  creates a Kestrel server. it's also going to read from our configuration files .json files,
// any configuration that we pass to it.

// Add services to the container.
//  Services - things we can use inside our code,

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt => // now we've got access to this particular method (AddDbContext) and we tell it about what class we're using (DataContext)
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); //  we're going to specify that we want to use SQL lights, our database needs a connection string.
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// Middlewear things that can do something with the HTTP request on
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}

catch (Exception ex) //error handeling
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}



app.Run();
