namespace Auto_ecole_project.Models
{
    public class SessionCondidat
    {
        public int SessionId { get; set; }
        public Session Session { get; set; }

        public int CondidatId { get; set; }
        public Condidat Condidat { get; set; }
    }
}
