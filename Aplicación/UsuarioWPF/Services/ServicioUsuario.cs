namespace UsuarioWPF.Services
{
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text;
    using System.Threading.Tasks;
    using UsuarioWPF.Models;
    using Newtonsoft.Json;
    using System.Collections.ObjectModel;

    public class ServicioUsuario: IServicioUsuario
    {
       private readonly string _url = @"http://localhost:5118/api/Usuario/";
        public async Task<bool> GuardarUsuario(Usuario usuario)
        {
            bool result = false;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(string.Format("{0}GuardarUsuario", _url), usuario);
          if(response.IsSuccessStatusCode)
                result = true;

          return result;

        }

        public async Task<ObservableCollection<Usuario>> ObtenerUsuarios()
        {
            ObservableCollection<Usuario> lstUsuarios = null;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(string.Format("{0}ObtenerUsuarios", _url));
            if (response.IsSuccessStatusCode)
            {
                lstUsuarios = await response.Content.ReadFromJsonAsync<ObservableCollection<Usuario>>();
            }
            return lstUsuarios;
        }



    }
}
