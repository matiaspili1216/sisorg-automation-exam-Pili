namespace sisorg_automation_exam_MP.Functions.DTOs
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
        public string FechaAlta { get; set; }

        public Cliente(int id, string nombre, string email, string telefono, string estado, string fechaAlta = "")
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
            Estado = estado;
            FechaAlta = fechaAlta;
        }

        public Cliente(string id, string nombre, string email, string telefono, string estado, string fechaAlta = "")
        {
            Id = int.Parse(id);
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
            Estado = estado;
            FechaAlta = fechaAlta;
        }
    }
}
