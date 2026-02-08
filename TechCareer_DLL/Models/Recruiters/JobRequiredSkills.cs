using TechCareer_DLL.Models.SiteSettings;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareer_DLL.Models.Recruiters
{
    public class JobRequiredSkills : BaseClass
    {
       
        [ForeignKey(nameof(JobPost))]
        public int JobID { get; set; } 

        [ForeignKey(nameof(Skill))]
        public int SkillID { get; set; }

        // Skill Requirement
        public bool IsMandatory { get; set; }

        // Navigation Properties
        public virtual JobPost JobPost { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
