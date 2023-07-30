using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("aspnetroles")]
    public class AspNetRole : IdentityRole<int>
    {
        [Key]
        [Column("id")]
        public override int Id { get; set; }
        [Column("name")]
        public override string Name { get; set; }
        [Column("normalized_name")]
        public override string NormalizedName { get; set; }
        [Column("concurrency_stamp")]
        public override string ConcurrencyStamp { get; set; }
    }
}
