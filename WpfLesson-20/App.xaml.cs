using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfLesson_20.ViewModels;

namespace WpfLesson_20
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            Views.CalcView view = new Views.CalcView();
            view.DataContext = new ViewModels.CalcVM();
            view.Show();
        }
    }
}
