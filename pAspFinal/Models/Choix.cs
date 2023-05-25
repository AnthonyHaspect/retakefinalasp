namespace pAspFinal.Models
{
    public class Choix
    {
        public int Id { get; set; }
        public string Options { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
