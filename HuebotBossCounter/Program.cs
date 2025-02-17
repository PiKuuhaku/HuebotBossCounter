using HuebotBossCounter.Domain.Interfaces;
using HuebotBossCounter.Infra.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.ComponentModel.Design;

namespace HuebotBossCounter
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var form = serviceProvider.GetRequiredService<BossCounter>();
                Application.Run(form);
            }

            //var form = new BossCounter();
            //var tabControl = new TabControlHelper(form.tabControl1);
            //tabControl.HidePage(form.tabHistorico);
            //tabControl.HidePage(form.tabAdicionar);

            //Application.Run(form);
        }

        static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                    .AddScoped<IUserContext, UserContext>()
                    .AddScoped<IBossContext, BossContext>()
                    .AddScoped<IKillsContext, KillsContext>();

            services.AddScoped<BossCounter>();
        }
    }
}