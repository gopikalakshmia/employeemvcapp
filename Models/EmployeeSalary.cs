using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using employeemvcapp.Models;
namespace employeemvcapp.Models;
public class EmployeeSalary()
{
    [Key]
    [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }
    [Required]
    public DateTime SalaryDate { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

}