namespace UsuarioWPF.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Xml.Linq;
    using UsuarioWPF.Commands;
    using UsuarioWPF.Models;
    using UsuarioWPF.Services;
    using UsuarioWPF.Views;
    public class UsuarioViewModel : ViewModelBase
    {
        private ObservableCollection<Usuario>? usuarios;
        private CrearUsuario crearUsuarioWindow;
        private GuardarAreaUsuario guardarAreaUsuarioView;
        private AsignarAreaViewModel _asignarArea;
        private IServicioUsuario _servicioCliente;
        public Usuario usuarioSeleccionado;
        public string nombre;
        public string apellido;
        public string cedula;
        public string direccion;
        public string mensaje;

        public UsuarioViewModel(IServicioUsuario servicioCliente, AsignarAreaViewModel asignarArea)
        {
            
            VentanaGuardarCommand = new RelayCommand(AbrirVentana, CanAbrirVentana);
            GuardarUsuarioCommand = new RelayCommand(GuardarUsuario, CanGuardarUsuario);
            AsignarAreaCommand = new RelayCommand(AsignarArea, CanAsignarArea);
            _servicioCliente = servicioCliente;
            _asignarArea = asignarArea;
            ConsultarUsuarios();


        }

        private async void ConsultarUsuarios()
        {
            try
            {
                Usuarios = await _servicioCliente.ObtenerUsuarios();
            }
            catch (Exception)
            {

                Mensaje = "Error al cargar los usuarios";
            }
            
        }

        public ICommand VentanaGuardarCommand { get; set; }
        public ICommand GuardarUsuarioCommand { get; set; }
        public ICommand AsignarAreaCommand { get; set; }

        public ObservableCollection<Usuario>? Usuarios
        {
            get
            {
                return usuarios;
            }
            set
            {
                usuarios = value;
                OnPropertyChanged(nameof(Usuarios));
            }
        }


        public Usuario UsuarioSeleccionado
        {
            get
            {
                return usuarioSeleccionado;
            }
            set
            {

                OnPropertyChanged(ref usuarioSeleccionado, value);
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {

                OnPropertyChanged(ref nombre, value);
            }
        }

        public string Mensaje
        {
            get
            {
                return mensaje;
            }
            set
            {

                OnPropertyChanged(ref mensaje, value);
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {

                OnPropertyChanged(ref apellido, value);
            }
        }

        public string Cedula
        {
            get
            {
                return cedula;
            }
            set
            {

                OnPropertyChanged(ref cedula, value);
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {

                OnPropertyChanged(ref direccion, value);
            }
        }


        private bool CanAbrirVentana(object obj)
        {
            return true;
        }

        private void AbrirVentana(object obj)
        {
            var mainWindow = obj as Window;
            crearUsuarioWindow = new CrearUsuario();
            crearUsuarioWindow.Owner = mainWindow;
            crearUsuarioWindow.DataContext = this;
            crearUsuarioWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            crearUsuarioWindow.Show();
        }

        private bool CanGuardarUsuario(object obj)
        {
            if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Cedula) && !string.IsNullOrEmpty(Apellido) && !string.IsNullOrEmpty(Direccion))
                return true;
            else
                return false;
        }

        private async void GuardarUsuario(object obj)
        {
            try
            {
                Mensaje = string.Empty;
                Usuario usuario = new Usuario();
                usuario.Nombre = Nombre;
                usuario.Apellido = Apellido;
                usuario.Direccion = Direccion;
                usuario.Cedula = Cedula;
                bool respuesta = await _servicioCliente.GuardarUsuario(usuario);
                if (respuesta)
                    Mensaje = "usuario guardado";
                else
                    Mensaje = "Error al guardar el usuario";
                ConsultarUsuarios();
                IniciarCampos();
                
            }
            catch (Exception)
            {

                Mensaje = "Error al guardar el usuario";
            }
            crearUsuarioWindow.Hide();
        }

        private void IniciarCampos()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
        }

        private bool CanAsignarArea(object obj)
        {
            
                return true;
           
        }

        private void AsignarArea(object obj)
        {
            if (UsuarioSeleccionado == null)
            {
                Mensaje = "Debe seleccionar un registro";
            }
            else
            {
                Mensaje = string.Empty;
                var mainWindow = obj as Window;
                guardarAreaUsuarioView = new GuardarAreaUsuario();
                guardarAreaUsuarioView.Owner = mainWindow;
                guardarAreaUsuarioView.DataContext = _asignarArea;
                _asignarArea.AsignarVariables(UsuarioSeleccionado, guardarAreaUsuarioView);
                _asignarArea.ConsultarAreas();
                _asignarArea.NotificarMensaje += MensajeAsignarArea;
                guardarAreaUsuarioView.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                guardarAreaUsuarioView.Show();

            }
        }

        private void MensajeAsignarArea(string mensaje)
        {
            Mensaje = mensaje;
            _asignarArea.NotificarMensaje -= MensajeAsignarArea;
        }

    }
}
