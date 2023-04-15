using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Application.Factories;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Infrastructure.Data;
using Sat.Recruitment.Infrastructure.Interfaces.Bases;
using Sat.Recruitment.Infrastructure.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SatRecruitmentContext>(options =>
	options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGifCalculationStrategyFactory, GifCalculationStrategyFactory>();
builder.Services.AddScoped(typeof(IBaseRepository<,>), 
	typeof(BaseRepository<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
	using (var dbContext = scope.ServiceProvider.GetService<SatRecruitmentContext>())
		if (dbContext != null) dbContext.Database.EnsureCreatedAsync();

app.UseAuthorization();
app.MapControllers();
app.Run();