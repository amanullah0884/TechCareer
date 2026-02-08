using System.ComponentModel.DataAnnotations;

namespace TechCareer_DLL.Models.SiteSettings.Location
{
    public class Division : BaseClass
    {
        [StringLength(30, ErrorMessage = "Division name cannot be longer than 30 characters.")]
        public string Name { get; set; } = string.Empty;
        public int CountryId { get; set; }

        // Navigation Property
        public virtual Country? Country { get; set; }
        public virtual ICollection<District> Districts { get; set; } = new List<District>();
    }
}
