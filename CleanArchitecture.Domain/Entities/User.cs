using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [MaxLength(150)]
    public string Name { get; set; }

    [Column("email")]
    [MaxLength(150)]
    public string Email { get; set; }

    [Column("password_hash")]
    public string PasswordHash { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}
