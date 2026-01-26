using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ExpenseControl.Application.Helpers
{
    public static class EnumHelper
    {
        public static string GetDisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var att = field?.GetCustomAttribute<DisplayAttribute>();

            return att?.Name ?? value.ToString();
        }
    }
}