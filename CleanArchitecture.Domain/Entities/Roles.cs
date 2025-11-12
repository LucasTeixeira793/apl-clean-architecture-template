using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

[Table("roles")]
public class Role
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [MaxLength(50)]
    public string Name { get; set; }

    [Column("description")]
    public string Description { get; set; }
}