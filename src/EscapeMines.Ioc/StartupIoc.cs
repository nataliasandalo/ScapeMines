using System;
using System.Diagnostics;
using System.IO;
using CursoOnline.Dominio._Base;
using EscapeMines.Data.Context;
using EscapeMines.Data.Repository;
using EscapeMines.Domain._Base;
using EscapeMines.Domain.Board;
using EscapeMines.Domain.Exitpoint;
using EscapeMines.Domain.Mines;
using EscapeMines.Domain.Turtle;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EscapeMines.Ioc
{
    public static class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration["Data:ConnectionStrings:DefaultConnection"]));
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IBoardRepository), typeof(BoardRepository));
            services.AddScoped(typeof(IMinesRepository), typeof(MinesRepository));
            services.AddScoped(typeof(IExitpointRepository), typeof(ExitpointRepository));
            services.AddScoped(typeof(ITurtleRepository), typeof(TurtleRepository));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped<Board>();
            services.AddScoped<AddBoard>();
            services.AddScoped<AddMines>();
            services.AddScoped<AddExitpoint>();
            services.AddScoped<AddTurtle>();
        }

        private static string GetBasePath()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var isDevelopment = environment == Environments.Development;
            if (isDevelopment)
            {
                return Directory.GetCurrentDirectory();
            }
            using var processModule = Process.GetCurrentProcess().MainModule;
            return Path.GetDirectoryName(processModule?.FileName);
        }

    }
}
