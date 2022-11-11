namespace Questionnaire.Entities.Models;

public class Element : BaseEntity
{
    public string Type { get; set; }
    public virtual ICollection<ElementOnForm> ElementOnForms { get; set; }
}
