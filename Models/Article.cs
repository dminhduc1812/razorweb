using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cs_razorweb.Models;
// [Table("posts")]
public class Article
{
    [Key]
    public int Id { get; set; }
    [StringLength(255, MinimumLength = 5, ErrorMessage = "{0} phai dai tu {2} ky tu den {1}")]
    [Required(ErrorMessage = "{0} phai nhap")]
    [Column(TypeName = "nvarchar")]
    [DisplayName("Tieu de")]
    public string Title { get; set; }
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "{0} phai nhap")]
    [DisplayName("Ngay tao")]
    public DateTime Created { get; set; }
    [Column(TypeName = "ntext")]
    [DisplayName("Noi dung")]
    public string Content { get; set; }
}