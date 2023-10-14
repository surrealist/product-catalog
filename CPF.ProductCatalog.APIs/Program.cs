using Microsoft.AspNetCore.Authentication.JwtBearer;
using CPF.ProductCatalog.Services.Data;
using Microsoft.EntityFrameworkCore;
using CPF.ProductCatalog.APIs.Services;

namespace CPF.ProductCatalog.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

            builder.Services.AddDbContext<AppDb>(options =>
            {
                //var cnString = builder.Configuration.GetConnectionString(nameof(AppDb));
                //options.UseSqlServer(cnString);
                var cnString = builder.Configuration.GetConnectionString("AppDbLite");
                options.UseSqlite(cnString);
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ILoggingService, LoggingService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsEnvironment("Development"))
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}