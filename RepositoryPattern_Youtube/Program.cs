using Microsoft.EntityFrameworkCore;
using RepositoryPattern_Youtube.Data.MusicRepo;
using RepositoryPattern_Youtube.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Register AddDbContext pool 
builder.Services.AddDbContextPool<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

// Register music service
builder.Services.AddScoped<IMusicService, MusicService>();


// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
