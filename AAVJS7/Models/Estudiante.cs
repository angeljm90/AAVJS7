using SQLite;

namespace AAVJS7.Models
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(225)]
        public string Nombre { get; set; }
        [MaxLength(225)]
        public string Usuario { get; set; }
        [MaxLength(225)]
        public string Contrasena { get; set; }
    }
}
