using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET6EmployeeDatabaseCRUDApplication.Models
{
    [Table("Department", Schema ="dbo")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = " Department Id ")]
        public int DepartmentId { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        [Display(Name = " Department Name")]
        public string DepartmentName { get; set; }

        [Column(TypeName = "varchar(5)")]
        [Display(Name = (" Department Abbreviation "))]
        public string DepartmentAbbr { get; set; }
    }
}
