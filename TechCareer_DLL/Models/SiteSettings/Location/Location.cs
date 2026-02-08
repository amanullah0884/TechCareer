using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareer_DLL.Models.SiteSettings.Location
{
    public class Location : BaseClass
    {
        public string DetailedAddress { get; set; } = string.Empty;

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [ForeignKey("Division")]
        public int DivisionId { get; set; }
        [ForeignKey("District")]
        public int DistrictId { get; set; }
        [ForeignKey("Area")]
        public int AreaId { get; set; }

        // Navigation Property
        public virtual Country? Country { get; set; }
        public virtual Division? Division { get; set; }
        public virtual District? District { get; set; }
        public virtual Area? Area { get; set; }

    }
}
