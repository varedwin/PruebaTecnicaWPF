using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioWPF.ViewModels
{
    public class MainViewModel:ViewModelBase
    {

        public UsuarioViewModel UsuarioViewModel { get; }


        public MainViewModel(UsuarioViewModel usuarioViewModel)
        {
            UsuarioViewModel = usuarioViewModel;
            

        }
    }
}
