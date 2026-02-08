using TechCareer_DLL.Models.Enums;
using TechCareer_DLL.Models.JobSeekers;
using TechCareer_DLL.Models.SiteSettings.JobModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareer_DLL.Models.Recruiters
{
    public class JobPost : BaseClass
    {
        // Foreign Keys with proper attributes
        [ForeignKey(nameof(Recruiter))]
        public int RecruiterID { get; set; }

        [ForeignKey(nameof(JobNature))]
        public int JobNatureId { get; set; }

        [ForeignKey(nameof(JobType))]
        public int JobTypeId { get; set; }

        [ForeignKey(nameof(JobCategory))]
        public int JobCategoryId { get; set; }

        // Job Details
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
        public short Vacancy { get; set; }
        public byte AgeRange { get; set; }
        public byte ExperienceMin { get; set; }
        public byte ExperienceMax { get; set; }
        public string ExpirenceDescription { get; set; }
        public string Requirements { get; set; }
        public string RequirementsDescription { get; set; }
        public string AdditionalRequirements { get; set; }
        public string AdditionalRequirementsDescription { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
        public bool IsSalaryNagotiable { get; set; }
        public DateTime ApplicationDeadLine { get; set; }
        public string ExternalApplyURL { get; set; }
        public PostingTier PostingTier { get; set; } // Enum

        // Navigation Properties
        public virtual Recruiter Recruiter { get; set; }
        public virtual JobNature JobNature { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual JobCategory JobCategory { get; set; }

        // One-to-Many Relationships
        public virtual ICollection<JobRequiredSkills> JobRequiredSkills { get; set; } = new List<JobRequiredSkills>();
        public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
        public virtual ICollection<SavedJobs> SavedJobs { get; set; } = new List<SavedJobs>();
    }
}
