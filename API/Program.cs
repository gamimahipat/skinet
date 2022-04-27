
using API.Extensions;
using API.Helpers;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//change
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddDbContext<StoreContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

//change
builder.Services.AddApplicationServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//change
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();

//change
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();

