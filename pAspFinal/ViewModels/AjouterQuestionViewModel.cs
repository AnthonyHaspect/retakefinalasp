using pAspFinal.Models;

namespace pAspFinal.ViewModels
{
    public class AjouterQuestionViewModel
    {
        public Question Question { get; set; }
        public List<Section> Sections { get; set; }
        public List<Question> Questions { get; set; }
        public List<Models.Type> Types { get; set; }
    }
}
