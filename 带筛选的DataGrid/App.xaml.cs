using Bogus;
using Prism.Ioc;
using System.Windows;
using 带筛选的DataGrid.Views;

namespace 带筛选的DataGrid
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Randomizer.Seed = new(1334);
        }
    }
}
