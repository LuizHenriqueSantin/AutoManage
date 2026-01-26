using System.ComponentModel.DataAnnotations;

namespace AutoManage.Domain.Enums
{
    public enum SystemVersion
    {
        [Display(Name = "Básico")]
        Basic = 1,

        [Display(Name = "Intermediário")]
        Medium = 2,

        [Display(Name = "Completo")]
        Complete = 3,
    }
}
