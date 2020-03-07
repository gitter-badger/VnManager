using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelManager.Windows;

namespace VisualNovelManager
{
    public class Bootstrapper : Bootstrapper<RootViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Configure the IoC container in here
        }

        protected override void Configure()
        {
            // Perform any other configuration before the application starts
            var startup = new Initializers.Startup();
            startup.RunStartupTasks();
        }
    }
}
