using AAVJS7.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AAVJS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public Estudiante datos;
        private SQLiteAsyncConnection _conn;
        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadoUpdate;
        public Elemento(Estudiante idDato)
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection();
            datos = idDato;
            txtNombre.Text = datos.Nombre;
            txtUsuario.Text = datos.Usuario;
            txtContrasena.Text = datos.Contrasena;

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var path = Path.Combine(documentsPath, "UISRAEL.DB3");
                var db = new SQLiteConnection(path);
                ResultadoDelete = Update(db, datos.Id, txtNombre.Text, txtUsuario.Text, txtContrasena.Text );

                DisplayAlert("Alerta", "Dato actualziadop", "Cerrar");



            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");

            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

           
                try
                {
                    var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                    var path = Path.Combine(documentsPath, "UISRAEL.DB3");
                    var db = new SQLiteConnection(path);
                    ResultadoDelete = Delete(db, datos.Id);
                    
                        DisplayAlert("Alerta", "Dato eliminado", "Cerrar");
                    


                }
                catch (Exception ex)
                {
                    DisplayAlert("Alerta", ex.Message, "Cerrar");

                }
          
        }


        public static IEnumerable<Estudiante>Delete (SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id=?", id);

        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, int id, string nombre, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("Update  Estudiante set Nombre=?, Usuario=?, Contrasena=? where Id=?", nombre, usuario, contrasena, id);

        }

       
    }
}