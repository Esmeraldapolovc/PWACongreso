namespace AppCongreso.Models
{
    public class Usuario
    {

        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Twitter { get; set; }
        
        public string Ocupacion { get; set; }

        public string AvatarUrl { get; set; }
    }
}
