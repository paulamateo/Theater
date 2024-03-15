using Theater.Business;
using Theater.Data;
using Microsoft.EntityFrameworkCore;
using Theater.Logging;

var builder = WebApplication.CreateBuilder(args);

var isRunningDocker = Environment.GetEnvironmentVariable("container") == "true";
var connectionKeyString = isRunningDocker ? "ServerDB_Docker" : "ServerDB_Local";
var connectionString = builder.Configuration.GetConnectionString(connectionKeyString);

builder.Services.AddDbContext<TheaterContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IShowRepository, ShowRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IShowService, ShowService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<ILogMethod, LogMethod>();


  
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

// using (var scope = app.Services.CreateScope()) {
//     var services = scope.ServiceProvider;
//     try {
//         var context = services.GetRequiredService<TheaterContext>();
//         context.Database.Migrate();
//     }catch (Exception e) {
//         throw new Exception("Error: ", e);
//     }
// }

// app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:5173")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
});

app.MapControllers();

app.Run();