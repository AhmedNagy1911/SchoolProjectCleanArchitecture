namespace SchoolProject.Data.Entities;

public class Parent
{
    public string Id { get; set; } = string.Empty;

    public virtual ApplicationUser User { get; set; } = default!;

    public virtual ICollection<ParentStudent> ParentStudents { get; set; } = [];
}
