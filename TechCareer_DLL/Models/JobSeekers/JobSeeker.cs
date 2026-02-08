using TechCareer_DLL.Models.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
    public class JobSeeker: BaseClass
    {
        //public int JobSeekerId { get; set; } // Primary Key
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        // Foreign Key -> User

        // Navigation properties
       // public virtual User User { get; set; }
        public virtual JobSeekerInformation JobSeekerInformation { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }
        public virtual ICollection<SavedJobs> SavedJobs { get; set; }
        public virtual ICollection<PersonalInformation> PersonalInformation { get; set; }
        public virtual ICollection<JobSeekerEducation> Educations { get; set; }
        public virtual ICollection<JobSeekerTraining> Trainings { get; set; }
        public virtual ICollection<JobSeekerCertification> Certifications { get; set; }
        public virtual ICollection<JobSeekerSkill> Skills { get; set; }
        public virtual ICollection<JobSeekerAchievement> Achievements { get; set; }
        public virtual ICollection<JobSeekerExperience> Experiences { get; set; }
        public virtual ICollection<CareerInformation> CareerInformation { get; set; }
        public virtual ICollection<PreferredJobInformation> PreferredJobInformation { get; set; }
        public virtual ICollection<JobSeekersKeyword> Keywords { get; set; }
        public virtual ICollection<JobSeekersSocialMedia> SocialMedias { get; set; }

    }
   

}
