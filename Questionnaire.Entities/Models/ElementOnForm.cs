namespace Questionnaire.Entities.Models;

public class ElementOnForm : BaseEntity
{
    public string Question { get; set; }
    public Guid FormId { get; set; }   
    public virtual Form Form { get; set; }
    public Guid ElementId { get; set; }
    public virtual Element Element { get; set; }
    public virtual ICollection<ResultOnQuestion> ResultOnQuestions { get; set; }
    public virtual ICollection<Variant> Variants { get; set; }
}
