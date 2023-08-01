using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.CustomAnnotations
{
    public class ArrayMustHaveOneElementAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList<object>;
            if (list != null)
            {
                return list.Count > 0;
            }
            return false;
        }
    }
}
