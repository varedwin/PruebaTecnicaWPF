using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UsuarioWPF.Services;
using UsuarioWPF.ViewModels;
using UsuarioWPF.Views;

namespace UsuarioWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServicioUsuario servicioCliente = new ServicioUsuario();
            IServicioArea servicioArea = new ServicioArea();
            AsignarAreaViewModel asignarArea = new AsignarAreaViewModel(servicioArea);
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel(servicioCliente, asignarArea);
            MainViewModel mainViewModel = new MainViewModel(usuarioViewModel);

            MainWindow = new MainWindow()
            {
                DataContext = mainViewModel
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
