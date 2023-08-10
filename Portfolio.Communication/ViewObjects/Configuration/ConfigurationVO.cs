using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.ViewObjects.Configuration
{
    public class SaveConfigurationVO
    {
        [Required(ErrorMessage = "Token não informado")]
        [StringLength(128, ErrorMessage = "Token deve ter entre 1 e 128 caracteres", MinimumLength = 1)]
        public string Token { get; set; }
        [Required(ErrorMessage = "Valor não informado")]
        [StringLength(255, ErrorMessage = "Valor deve ter entre 1 e 255 caracteres", MinimumLength = 1)]
        public string Value { get; set; }
        [StringLength(255, ErrorMessage = "Extra deve ter entre 1 e 255 caracteres")]
        public string? Extra { get; set; }
    }

    public class ConfigurationVO : SaveConfigurationVO
    {
        public int Id { get; set; }
    }
}
