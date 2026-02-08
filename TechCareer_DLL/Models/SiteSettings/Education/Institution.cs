using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer_DLL.Models.SiteSettings.Education
{
    public class Institution : BaseClass
    {
        public string Name { get; set; } = string.Empty;
        public string InstituteType { get; set; }

        // Navigation properties
        public virtual ICollection<JobSeekerEducation> JobSeekerEducations { get; set; }

    }
}
