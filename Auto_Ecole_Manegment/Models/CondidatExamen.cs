namespace Auto_ecole_project.Models
{
    public class CondidatExamen
    {
        public Condidat Condidat { get; set; }
        public Examen Examen { get; set; }

        public DateOnly DateExamen { get; set; }
    }
}
