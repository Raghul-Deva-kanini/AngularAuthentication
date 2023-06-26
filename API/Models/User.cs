using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace RoleBasedAuthorization.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? Id { get; set; }
        public string? Email { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        /*[Column(TypeName = "Date")]*/
        /*public DateTime DateOfBirth { get; set; }*/
        public string Gender { get; set; } = string.Empty;
        public string Role { get; set; }=string.Empty;
        public byte[]? Password { get; set; }
        public byte[]? HashKey { get; set; }
    }
}
