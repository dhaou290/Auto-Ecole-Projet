namespace Auto_ecole_project.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duree { get; set; }
        public string Type { get; set; }
        // Foreign keys
        public int ClientId { get; set; }
        public int MoniteurId { get; set; }
        public int VoitureId { get; set; }

        public int CoursId { get; set; }


    }
}
