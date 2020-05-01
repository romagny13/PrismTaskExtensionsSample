using Prism.Ioc;
using PrismTaskExtensionsSample.Views;
using System.Windows;

namespace PrismTaskExtensionsSample
{

    public partial class App 
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
