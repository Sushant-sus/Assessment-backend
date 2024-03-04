using Foodmandu.Model;
using Foodmandu.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin",
                              builder => builder.AllowAnyOrigin()
                                                .AllowAnyMethod()
                                                .AllowAnyHeader());
        });
        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<FoodmanduDbContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,      
                    maxRetryDelay: TimeSpan.FromSeconds(30), 
                    errorNumbersToAdd: null); 
            });
        });

        services.AddScoped<ILayoutService, LayoutService>();
        services.AddScoped<IFileServices , FileServices>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var mySetting = Configuration["MySetting"];

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.UseRouting();
        app.UseCors("AllowAnyOrigin");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
