using Microsoft.EntityFrameworkCore;
using RoyalSoftSellingSystem.Models;
using RoyalSoftSellingSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "default", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var xmlFile = Path.Combine(AppContext.BaseDirectory, "RoyalSoftSellingSystem.xml");
if (File.Exists(xmlFile))
{
    builder.Services.AddSwaggerGen(c => c.IncludeXmlComments(xmlFile));
}
else
{
    builder.Services.AddSwaggerGen();
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddScoped<PurchaseInvoiceService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

app.UseCors("default");


app.MapControllers();

app.Run();
