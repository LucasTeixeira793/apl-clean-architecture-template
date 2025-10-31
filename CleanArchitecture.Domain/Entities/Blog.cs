using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities
{
    /// <summary>
    /// Represents the Postgres' table BLOG
    /// </summary>
    [Table("blog")]
    public class Blog
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = String.Empty;

        [Column("description")]
        public string Description { get; set; } = String.Empty;

        [Column("author")]
        public string Author { get; set; } = String.Empty;

        [Column("image_url")]
        public string ImageUrl { get; set; } = String.Empty;
    }
}
