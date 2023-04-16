using Microsoft.AspNetCore.Mvc.ModelBinding;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Extensions
{
    public static class ModelStateExtensions
    {
        public static string AllErrors(this ModelStateDictionary modelState)
        {
            return string.Join(" | ", modelState.Values
                               .SelectMany(v => v.Errors)
                               .Select(e => e.ErrorMessage));
        }
    }
}
