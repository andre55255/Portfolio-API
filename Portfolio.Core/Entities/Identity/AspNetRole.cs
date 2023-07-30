using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("SC_ASPNETROLES")]
    public class AspNetRole : IdentityRole<int>
    {
        [Key]
        [Column("ID")]
        public override int Id { get; set; }
        [Column("NAME")]
        public override string Name { get; set; }
        [Column("NORMALIZED_NAME")]
        public override string NormalizedName { get; set; }
        [Column("CONCURRENCY_STAMP")]
        public override string ConcurrencyStamp { get; set; }
    }
}
