
using DbWebApi.Context;
using Microsoft.EntityFrameworkCore;

namespace DbWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<ItemsDBContext>(opt => opt.UseNpgsql("Host=192.168.0.55;Port=5433;Database=ItemsDB;Username=dbadmin;Password=Ntcnjvlfk123"));


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

            app.MapControllers();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.Run();
        }
    }
}