using Domain.Interfaces;
using Persistence.Context;
using Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistenceApp(this IServiceCollection services,
                                                IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("QuizCnn");

        var mysqlServerVersion = new MySqlServerVersion(new Version(9, 0, 0));

        services.AddEntityFrameworkMySql()
            .AddDbContext<AppDbContext>(
                options => options.UseMySql(connectionString, mysqlServerVersion)
        );

        services.AddScoped<IUserRepository, UserRepository>();
    }
}
