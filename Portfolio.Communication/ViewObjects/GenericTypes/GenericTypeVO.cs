using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.ViewObjects.GenericTypes
{
    public class SaveGenericTypeVO
    {
        [Required(ErrorMessage = "Token não informado")]
        [StringLength(255, ErrorMessage = "Token deve ter entre 1 e 255 caracteres", MinimumLength = 1)]
        public string Token { get; set; }
        [Required(ErrorMessage = "Valor não informado")]
        [StringLength(512, ErrorMessage = "Valor deve ter entre 1 e 512 caracteres", MinimumLength = 1)]
        public string Value { get; set; }
        [Required(ErrorMessage = "Descrição não informada")]
        [StringLength(1024, ErrorMessage = "Descrição deve ter entre 1 e 1024 caracteres", MinimumLength = 1)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Valor booleano não informado")]
        public bool? ValueBool { get; set; } = false;
    }

    public class GenericTypeVO : SaveGenericTypeVO
    {
        public int Id { get; set; } = 0;
    }
}
