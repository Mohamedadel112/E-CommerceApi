using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class RoleVM
    {
        [Required(ErrorMessage =("Enter A Name"))]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
