using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using CursoOnline.Dominio._Base;
using EscapeMines.Data.Context;
using EscapeMines.Data.Repository;
using EscapeMines.Domain._Base;
using EscapeMines.Domain.Board;
using EscapeMines.Domain.Exitpoint;
using EscapeMines.Domain.Mines;
using EscapeMines.Domain.Turtle;
using EscapeMines.Ioc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EscapeMines
{
    class Program
    {
        static void Main(string[] args)
        {
            //if you want to include in the data base
            var builder = new ConfigurationBuilder().SetBasePath(GetBasePath())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration configuration = builder.Build();
            var serviceCollection = new ServiceCollection();

            //setup our DI
            StartupIoc.ConfigureServices(serviceCollection, configuration);

            //do the actual work here
            var boardService = serviceCollection.BuildServiceProvider().GetService<IBoardRepository>();
            var addService = serviceCollection.BuildServiceProvider().GetService<AddBoard>();

            //the game without connection with database
            var game = Game.Models.Game.CreateNewGame();
            game.Start();

            Thread.Sleep(60000);
            System.Console.ReadKey();
        }
        private static string GetBasePath()
        {
            using var processModule = Process.GetCurrentProcess().MainModule;
            return Path.GetDirectoryName(processModule?.FileName);
        }
    }
}
