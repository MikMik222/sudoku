using Microsoft.Extensions.DependencyInjection;
using sudoku.Services.FileDialog;
using sudoku.Services.Loader;
using sudoku.Services.Saver;
using sudoku.Services.Solver;
using System;

namespace sudoku.Configuration
{
    internal class AppHost
    {

        private readonly ServiceProvider _serviceProvider;

        public AppHost()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MainWindow>();
            services.AddScoped<ISudokuSolver, SudokuSolver>();
            services.AddScoped<ISudokuBoardConverter, SudokuBoardConverter>();
            services.AddScoped<ISaveData, SaveJson>();
            services.AddScoped<IOpenDialog, OpenDialogForJSON>();
            services.AddScoped<ILoadData, LoadJSON>();
        }

        public T GetService<T>() where T : notnull
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}