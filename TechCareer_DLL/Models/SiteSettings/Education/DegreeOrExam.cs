using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareer_DLL.Models.SiteSettings.Education
{
    public class DegreeOrExam : BaseClass
    {
        [StringLength(30, ErrorMessage = "Degree/Exam name cannot be longer than 30 characters.")]
        public string Name { get; set; } = string.Empty;
        [ForeignKey("LevelOfEducation")]
        public int LevelOfEducationId { get; set; }

        // Navigation property
        public virtual LevelOfEducation? LevelOfEducation { get; set; }


    }
}
