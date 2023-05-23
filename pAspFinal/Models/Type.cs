namespace pAspFinal.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Balise { get; set; }
        public string? type { get; set; }
        public List<Question>? Questions { get; set; }  //relation 1 à N

    }
}
