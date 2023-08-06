using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.ViewObjects.Account
{
    public class SetPortfolioSelectedVO
    {
        [Required(ErrorMessage = "Portoflio não encontrado")]
        public int PortfolioId { get; set; }
    }
}
