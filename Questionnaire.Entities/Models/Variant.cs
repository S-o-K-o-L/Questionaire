namespace Questionnaire.Entities.Models;

public class Variant : BaseEntity
{
    public string VariantText { get; set; }
    public Guid ElementOnFormId { get; set; }
    public virtual ElementOnForm ElementOnForm { get; set; }
    public virtual ICollection<ResultOnQuestion> ResultOnQuestions { get; set; }
}
