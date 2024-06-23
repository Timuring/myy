using System.Configuration;
using System.Data;
using System.Windows;
using service.Models;

namespace service
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceContext context { get; } = new ServiceContext();

    }
}
