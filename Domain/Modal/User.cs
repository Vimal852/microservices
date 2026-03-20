using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Modal
{
    [Table("User", Schema = "public")]
    public class User
    {
        [Column("Id")] public Guid Id { get; set; } = Guid.NewGuid();
        [Column("Email")] public string Email { get; set; } = default!;
        [Column("PasswordHash")] public string PasswordHash { get; set; } = default!;
        [Column("FullName")] public string FullName { get; set; } = default!;
        [Column("Role")] public UserRole Role { get; set; } = UserRole.User;
        [Column("CompanyId")] public int CompanyId { get; set; }
        [Column("IsActive")] public bool IsActive { get; set; } = true;
        [Column("CreatedAt")] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Company Company { get; set; } = null!;
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}