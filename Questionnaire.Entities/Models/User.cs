namespace Questionnaire.Entities.Models;

public class User : BaseEntity
{
    public string PasswordHash { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public virtual ICollection<Form> Forms { get; set; }
    public virtual ICollection<Result> Results { get; set; }
}
