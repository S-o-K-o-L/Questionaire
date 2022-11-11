namespace Questionnaire.Entities.Models;

public class ResultOnQuestion : BaseEntity
{
    public string Answer { get; set; }
    public Guid ElementOnFormId { get; set; }
    public virtual ElementOnForm ElementOnForm { get; set; }
    public Guid? VariantId { get; set; }
    public virtual Variant Variant { get; set; }
    public Guid ResultId { get; set; }
    public virtual Result Result { get; set; }
}
