using Comazzi.DB;
using Comazzi.DB.Local;

namespace Comazzi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var connectionString = config.GetValue<string>("ConnectionString");

            builder.Services.AddSingleton<ConnectionStringProvider>(new ConnectionStringProvider(connectionString));

            builder.Services.AddScoped<PaisServer>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors(x => x
                .AllowAnyOrigin() // ("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
