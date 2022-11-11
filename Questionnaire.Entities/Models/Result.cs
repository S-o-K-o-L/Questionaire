namespace Questionnaire.Entities.Models;

public class Result : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public Guid FormId { get; set; }
    public virtual Form Form { get; set; }
    public virtual ICollection<ResultOnQuestion> ResultOnQuestions { get; set; }
}
