using Theater.Business;
using Theater.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IShowService, ShowService>();
builder.Services.AddScoped<IUserService, UserService>();

var connectionString = builder.Configuration.GetConnectionString("ServerDB");

builder.Services.AddDbContext<TheaterContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IShowRepository, ShowRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
  
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

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// using (var scope = app.Services.CreateScope()) {
//     var services = scope.ServiceProvider;
//     try {
//         var context = services.GetRequiredService<TheaterContext>();
//         context.Database.Migrate();
//     }catch (Exception ex) {
//     throw new Exception($"Error: {ex.Message}");
//   }
// }

app.Run();
