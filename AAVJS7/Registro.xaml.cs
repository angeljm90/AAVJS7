using AAVJS7.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AAVJS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Registro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var DatosRegistros = new Estudiante { Nombre = txtNopmbre.Text, Usuario = txtUsuario.Text, Contrasena = txtContrasena.Text };
            _conn.InsertAsync(DatosRegistros);
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNopmbre.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            DisplayAlert("Exito", "Se agrego correctamente", "Cerrar") ;
        }
    

 
    }
}