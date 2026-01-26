using System.ComponentModel.DataAnnotations;

namespace AutoManage.Domain.Enums
{
    public enum VehicleColor
    {
        [Display(Name = "Preto")]
        Black = 1,

        [Display(Name = "Branco")]
        White = 2,

        [Display(Name = "Prata")]
        Silver = 3,

        [Display(Name = "Azul")]
        Blue = 4,

        [Display(Name = "Vermelho")]
        Red = 5,
    }
}
