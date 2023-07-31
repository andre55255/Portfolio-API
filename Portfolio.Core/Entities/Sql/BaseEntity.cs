using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Sql
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Column("disabled_at")]
        public DateTime? DisabledAt { get; set; } = null;
    }
}
