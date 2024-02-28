using Theater.Business;
using Theater.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IShowService, ShowService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShowRepository, ShowRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var connectionString = builder.Configuration.GetConnectionString("ServerDB");

builder.Services.AddDbContext<TheaterContext>(options =>
    options.UseSqlServer(connectionString));
  
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

using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    try {
        var context = services.GetRequiredService<TheaterContext>();
        context.Database.Migrate();
    }catch (Exception e) {
        throw new Exception("Error: ", e);
    }
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();