using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Modal
{
    [Table("Company", Schema = "public")]
    public class Company
    {
        [Column("Id")] public int Id { get; set; }
        [Column("CompanyName")] public string? CompanyName { get; set; }
        [Column("Time")] public int Time { get; set; }
        [Column("Email")] public string? Email { get; set; }
        [Column("PhoneNumber")] public string? PhoneNumber { get; set; }
        [Column("Website")] public string? Website { get; set; }
        [Column("Address")] public string? Address { get; set; }
        [Column("City")] public string? City { get; set; }
        [Column("Country")] public string? Country { get; set; }
        [Column("LogoUrl")] public string? LogoUrl { get; set; }
        [Column("SubscriptionPlan")] public string? SubscriptionPlan { get; set; }
        [Column("IsActive")] public bool IsActive { get; set; } = true;
        [Column("CreatedAt")] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("UpdatedAt")] public DateTime? UpdatedAt { get; set; }

        public ICollection<User> Users { get; set; } = [];
    }
}