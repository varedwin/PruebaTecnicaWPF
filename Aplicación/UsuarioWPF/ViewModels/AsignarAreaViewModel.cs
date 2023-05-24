using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UsuarioWPF.Commands;
using UsuarioWPF.DTO;
using UsuarioWPF.Models;
using UsuarioWPF.Services;
using UsuarioWPF.Views;

namespace UsuarioWPF.ViewModels
{
    public class AsignarAreaViewModel : ViewModelBase
    {
        private ObservableCollection<Area>? areas;
        private Usuario? usuarioVm;
        private Area? areaSeleccionada;
        private GuardarAreaUsuario guardarAreaUsuarioView;
        IServicioArea _servicioArea;
        public string nombre;
        public string apellido;
        public string cedula;
        public string mensaje;
        public event Action<string> NotificarMensaje;

        public AsignarAreaViewModel(IServicioArea servicioArea)
        {
           
            GuardarUsuarioCommand = new RelayCommand(GuardarUsuario, CanGuardarUsuario);
            _servicioArea = servicioArea;
        }


        public async void ConsultarAreas()
        {
            try
            {
                Areas = await _servicioArea.ObtenerAreas();
            }
            catch (Exception)
            {

                Mensaje = "Error al cargar las Áreas";
            }

        }

        public ObservableCollection<Area>? Areas
        {
            get
            {
                return areas;
            }
            set
            {
                areas = value;
                OnPropertyChanged(nameof(Areas));
            }
        }

        public Area? AreaSeleccionada
        {
            get
            {
                return areaSeleccionada;
            }
            set
            {
                areaSeleccionada = value;
                OnPropertyChanged(nameof(AreaSeleccionada));
            }
        }

        public Usuario? UsuarioVm
        {
            get
            {
                return usuarioVm;
            }
            set
            {
                usuarioVm = value;
                OnPropertyChanged(nameof(UsuarioVm));
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

        public ICommand GuardarUsuarioCommand { get; set; }
        private bool CanGuardarUsuario(object obj)
        {
            return true;
        }

        private async void GuardarUsuario(object obj)
        {
            if (AreaSeleccionada == null)
            {
                Mensaje = "Debe seleccionar una Área";
            }
            else {
                Mensaje = string.Empty;
                UsuarioArea usuarioArea = new UsuarioArea();
                usuarioArea.Cedula = UsuarioVm.Cedula;
                usuarioArea.IdArea = AreaSeleccionada.Id;
                bool respuesta = await _servicioArea.AsignarUsuarioArea(usuarioArea);
                if (respuesta)
                { Mensaje = "Área asignada correctamente";
                    if (NotificarMensaje != null)
                        NotificarMensaje(Mensaje);
                }
                guardarAreaUsuarioView.Hide();
                
            }
        }


        public void AsignarVariables(Usuario usuarioSeleccionado, GuardarAreaUsuario _guardarAreaUsuarioView)
        {
            guardarAreaUsuarioView = _guardarAreaUsuarioView;
            UsuarioVm = usuarioSeleccionado;
            Nombre = UsuarioVm.Nombre;
            Apellido = UsuarioVm.Apellido;
            Cedula = UsuarioVm.Cedula;
            Mensaje = string.Empty;

        }

    }
}
