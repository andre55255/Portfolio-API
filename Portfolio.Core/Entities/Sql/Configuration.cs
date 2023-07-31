using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Sql
{
    [Table("configuration")]
    public class Configuration : BaseEntity
    {
        [Column("token")]
        public string Token { get; set; }
        [Column("value")]
        public string Value { get; set; }
        [Column("extra")]
        public string Extra { get; set; }
    }
}
