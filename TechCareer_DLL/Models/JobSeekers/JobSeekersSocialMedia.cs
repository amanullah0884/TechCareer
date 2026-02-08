using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareer_DLL.Models.JobSeekers
{
    public class JobSeekersSocialMedia: BaseClass
    {

        //[Key]
        //public int Id { get; set; } // Primary Key

        [Required]
        [ForeignKey("SocialMedia")]
        public int SocialMediaId { get; set; } // Foreign Key -> SocialMedia

        [Required]
        [ForeignKey("JobSeeker")]
        public int JobSeekerId { get; set; } // Foreign Key -> JobSeeker

        [MaxLength(300)]
        public string? ProfileLink { get; set; } // Example: https://linkedin.com/in/username

        // 🔹 Navigation properties
        //public virtual SocialMedia? SocialMedia { get; set; }
        public virtual JobSeeker? JobSeeker { get; set; }
    }
}