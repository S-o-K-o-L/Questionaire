namespace Questionnaire.Entities.Models;

public class Form : BaseEntity
{
    public string? Description { get; set; }
    public string AccessCode { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<Result> Results { get; set; }    
    public virtual ICollection<ElementOnForm> ElementOnForms { get; set; }
}