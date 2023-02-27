using HueFes.Core.IServices;
using HueFes.Core.Services;
using HueFes.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HueFesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HueFes")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(ILocationService), typeof(LocationService));
builder.Services.AddTransient(typeof(ILocationCategoryService), typeof(LocationCategoryService));
builder.Services.AddTransient(typeof(IEventService), typeof(EventService));
builder.Services.AddTransient(typeof(IShowService), typeof(ShowService));
builder.Services.AddTransient(typeof(IShowCategoryService), typeof(ShowCategoryService));
builder.Services.AddTransient(typeof(IHelpMenuService), typeof(HelpMenuService));
builder.Services.AddTransient(typeof(INewsService), typeof(NewsService));
builder.Services.AddTransient(typeof(IFavouriteService), typeof(FavouriteService));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
