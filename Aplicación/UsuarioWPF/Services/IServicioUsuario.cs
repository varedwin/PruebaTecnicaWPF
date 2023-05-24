using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioWPF.Models;

namespace UsuarioWPF.Services
{
    public interface IServicioUsuario
    {
        public Task<bool> GuardarUsuario(Usuario usuario);
        public Task<ObservableCollection<Usuario>> ObtenerUsuarios();
    }
}
