using AppPostRequestPhp.Models;
using AppPostRequestPhp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppPostRequestPhp.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        WebApiClientService webApi = new WebApiClientService();

        private ObservableCollection<EmpleadoModel> listaEmpleados;

        public ObservableCollection<EmpleadoModel> ListaEmpleados
        {
            get { return listaEmpleados; }
            set { listaEmpleados = value; RaisePropetyChanged(); }
        }

        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; RaisePropetyChanged(); }
        }

        public ICommand ConsultaListaEmpleadosPostCommand { get; set; }
        public MainViewModel()
        {
            ConsultaListaEmpleadosPostCommand = new Command(async () => await ConsultaListaEmpleadosPost());
        }

        public async Task ConsultaListaEmpleadosPost()
        {
            var paramsPost = new { IdEmpresa = Id };

            ListaEmpleados = await webApi.executeRequestPost<ObservableCollection<EmpleadoModel>>(paramsPost);
        }



    }
}
