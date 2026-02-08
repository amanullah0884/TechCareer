using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareer_DLL.Models.SiteSettings.Location
{
    public class District : BaseClass
    {
        [StringLength(30, ErrorMessage = "District name cannot be longer than 30 characters.")]
        public string Name { get; set; } = string.Empty;
        [ForeignKey("Division")]
        public int DivisionId { get; set; }

        // Navigation Property
        public virtual Division? Division { get; set; }
        public virtual ICollection<Area> Areas { get; set; } = new List<Area>();
    }
}
