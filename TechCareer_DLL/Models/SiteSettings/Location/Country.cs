using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TechCareer_DLL.Models.SiteSettings.Location
{
    public class Country : BaseClass
    {
        [StringLength(30, ErrorMessage = "Country name cannot be longer than 30 characters.")]
        public string Name { get; set; } = string.Empty;

      // Navigation Property
      [ValidateNever]
      public virtual ICollection<Division>? Divisions { get; set; } = new List<Division>();
   }
}
