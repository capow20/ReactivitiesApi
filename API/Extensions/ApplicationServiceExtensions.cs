using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serivces, IConfiguration config)
        {
            serivces.AddEndpointsApiExplorer();
            serivces.AddSwaggerGen();
            serivces.AddDbContext<DataContext>(opt => opt.UseSqlite(config.GetConnectionString("DefaultConnection")));
            serivces.AddCors(opt => opt.AddPolicy("CorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000")));
            serivces.AddMediatR(typeof(List.Handler));
            serivces.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return serivces;
        }
    }
}