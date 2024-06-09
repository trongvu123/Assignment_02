
using System.IO;
using System.Windows;

namespace MiniHotelManagement
{
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loginWindow = new Login_Window();
           
        }
    }
}
