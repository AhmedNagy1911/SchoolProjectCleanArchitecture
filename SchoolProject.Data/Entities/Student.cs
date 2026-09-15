using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities;

//الطالب ممكن يدرس مواد كتير، والمادة ممكن تكون عند طلاب كتير.
public class Student
{
    [Key]
    public int StudID { get; set; }
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;
    [StringLength(500)]
    public string Address { get; set; } = string.Empty;
    [StringLength(500)]
    public string Phone { get; set; } = string.Empty;
    public int? DID { get; set; }

    [ForeignKey("DID")]
    public virtual Department Department { get; set; } = default!;
}