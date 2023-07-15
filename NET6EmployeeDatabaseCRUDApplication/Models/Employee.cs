using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NET6EmployeeDatabaseCRUDApplication.Models
{
    [Table("Employee",Schema="dbo")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Employee Id")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        [MaxLength(15)]
        [Display(Name = "Employee No.")]
        public int EmployeeNo { get; set; }

        [Column(TypeName = "varchar(80)")]
        [MaxLength(80)]
        [Required]
        [Display (Name="Employee Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = " Date Of Birth ")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime DOB { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = " Hiring Date ")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime HiringDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = " Gross Salary ")]
        public decimal GrossSalary { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = " Net Salary ")]
        public decimal NetSalary { get; set; }

        [ForeignKey("Department")]
        [Required]
        public int DepartmentId { get; set; }

        [Display(Name = " Department ")]
        [NotMapped]
        public string DepartmentName { get; set; }


        public virtual Department Department { get; set; }



    }
}
