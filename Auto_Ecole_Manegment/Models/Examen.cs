namespace Auto_ecole_project.Models
{
    public class Examen
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public String Lieu { get; set; }

        // Foreign keys
        public int ClientId { get; set; }
        public int VoitureId { get; set; }

  }
}
