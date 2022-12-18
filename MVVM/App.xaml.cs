using Bogus;
using MVVM.Views;
using Prism.Ioc;
using System.Windows;

namespace MVVM
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
