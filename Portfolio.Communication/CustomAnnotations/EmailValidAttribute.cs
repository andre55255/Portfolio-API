using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Portfolio.Communication.CustomAnnotations
{
    public class EmailValidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                string email = value as string;
                if (email == null)
                    return false;

                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                Match match = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
                return match.Success;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
