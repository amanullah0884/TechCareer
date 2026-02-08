using System.ComponentModel.DataAnnotations;

namespace TechCareer_DLL.Models.SiteSettings.JobModule
{
    public class JobCategory : BaseClass
    {
        [StringLength(40, ErrorMessage = "Job category name cannot be longer than 40 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
