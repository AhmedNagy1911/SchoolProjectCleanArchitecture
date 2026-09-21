namespace SchoolProject.Data.Entities;

public class ParentStudent
{
    public int Id { get; set; }
    public string ParentId { get; set; } = string.Empty;
    public int StudID { get; set; }
    public string Relationship { get; set; } = string.Empty;  // Father / Mother / Guardian ...

    public virtual Parent Parent { get; set; } = default!;
    public virtual Student Student { get; set; } = default!;
}
