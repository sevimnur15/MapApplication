using BasarsoftFirst.congrate;
using BasarsoftFirst.data;
using BasarsoftFirst.Service;
using BasarsoftFirst.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ItemDb>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Generic repository için
// builder.Services.AddScoped<IRepository<BasarsoftFirst.congrate.Item>, Repository<BasarsoftFirst.congrate.Item>>();
//builder.Services.AddScoped<IItemManager<BasarsoftFirst.congrate.Item>, ItemDbService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // UnitOfWork'ü generic olmayan yapý ile ekleyin

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
