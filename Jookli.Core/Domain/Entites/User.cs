
using System.ComponentModel.DataAnnotations;

namespace Jookli.Core.Domain.Entites
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        [StringLength(50)]
        public string? UserName { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        public bool Premium { get; set; }
    }
}
