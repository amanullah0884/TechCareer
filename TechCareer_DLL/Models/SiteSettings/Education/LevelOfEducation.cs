namespace TechCareer_DLL.Models.SiteSettings.Education
{
    public class LevelOfEducation : BaseClass
    {
        public string Name { get; set; } = string.Empty;
        
        // Navigation Property
        public virtual ICollection<DegreeOrExam> DegreeOrExams { get; set; } = new List<DegreeOrExam>();

    }
}
