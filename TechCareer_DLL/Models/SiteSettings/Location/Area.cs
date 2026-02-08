using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareer_DLL.Models.SiteSettings.Location
{
    public class Area : BaseClass
    {
        public string Name { get; set; } = string.Empty;
        [ForeignKey("District")]
        public int DistrictId { get; set; }

        // Navigation Property
        public virtual District? District { get; set; }
    }
}
