using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UsuarioWPF.DTO;
using UsuarioWPF.Models;

namespace UsuarioWPF.Services
{
    public class ServicioArea : IServicioArea
    {
        private readonly string _url = @"http://localhost:5118/api/Area/";
        public async Task<bool> AsignarUsuarioArea(UsuarioArea usuarioArea)
        {
            bool result = false;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(string.Format("{0}AsignarUsuarioArea", _url), usuarioArea);
            if (response.IsSuccessStatusCode)
                result = true;

            return result;
        }

        public async Task<ObservableCollection<Area>> ObtenerAreas()
        {
            ObservableCollection<Area> lstAreas = null;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(string.Format("{0}ObtenerAreas", _url));
            if (response.IsSuccessStatusCode)
            {
                lstAreas = await response.Content.ReadFromJsonAsync<ObservableCollection<Area>>();
            }
            return lstAreas;
        }
    }
}
