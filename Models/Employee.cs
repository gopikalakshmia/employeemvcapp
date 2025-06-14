using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace employeemvcapp.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    [Required]
    [DisplayName("First Name")]
    public string FirstName { get; set; }
    [Required]
    [DisplayName("Last Name")]
    public string LastName { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Zip { get; set; }

    public DateTime CreatedDate { get; set; }

    //forignkey
    public ICollection<EmployeeSalary> Salaries { get; set; }

}