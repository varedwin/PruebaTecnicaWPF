using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioWPF.DTO;
using UsuarioWPF.Models;

namespace UsuarioWPF.Services
{
    public interface IServicioArea
    {
        public Task<bool> AsignarUsuarioArea(UsuarioArea usuarioArea);
        public Task<ObservableCollection<Area>> ObtenerAreas();
    }
}
