namespace Portfolio.Core.Entities.Sql
{
    public class GenericType : BaseEntity
    {
        public string Token { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public bool? ValueBool { get; set; }
    }
}
