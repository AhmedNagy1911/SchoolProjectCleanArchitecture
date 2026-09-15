using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities;


public class StudentSubject
{
    [Key]
    public int StudSubID { get; set; }
    public int StudID { get; set; }
    public int SubID { get; set; }

    [ForeignKey("StudID")]
    public virtual Student Student { get; set; } = default!;

    [ForeignKey("SubID")]
    public virtual Subjects Subject { get; set; } = default!;

}