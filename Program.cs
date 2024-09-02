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
builder.Services.AddScoped<IRepository<BasarsoftFirst.congrate.Item>, Repository<BasarsoftFirst.congrate.Item>>(); // Item için repository ekle
builder.Services.AddScoped<IRepository<WktModels>, Repository<WktModels>>(); // WktModels için repository ekle
builder.Services.AddScoped<IItemManager<BasarsoftFirst.congrate.Item>, ItemDbService>(); // ItemDbService'i ekle
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // UnitOfWork'i ekle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1:5500")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
