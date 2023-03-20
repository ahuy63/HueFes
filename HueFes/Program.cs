using HueFes.Core.IServices;
using HueFes.Core.Services;
using HueFes.Data;
using HueFes.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HueFesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HueFes")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

//JWT
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(jwt =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false
        };
    });


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(ILocationService), typeof(LocationService));
builder.Services.AddTransient(typeof(ILocationCategoryService), typeof(LocationCategoryService));
builder.Services.AddTransient(typeof(IEventService), typeof(EventService));
builder.Services.AddTransient(typeof(IShowService), typeof(ShowService));
builder.Services.AddTransient(typeof(IShowCategoryService), typeof(ShowCategoryService));
builder.Services.AddTransient(typeof(IHelpMenuService), typeof(HelpMenuService));
builder.Services.AddTransient(typeof(INewsService), typeof(NewsService));
builder.Services.AddTransient(typeof(IFavouriteService), typeof(FavouriteService));
builder.Services.AddTransient(typeof(ICustomerService), typeof(CustomerService));
builder.Services.AddTransient(typeof(ITicketService), typeof(TicketService));
builder.Services.AddTransient(typeof(ITicketTypeService), typeof(TicketTypeService));
builder.Services.AddTransient(typeof(IStaffService), typeof(StaffService));
builder.Services.AddTransient(typeof(ICheckinService), typeof(CheckinService));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
