using TechCareer_DLL.Models.BillingInformation;
using System.ComponentModel.DataAnnotations;

namespace TechCareer_DLL.Models.Recruiters
{
   public class Recruiter: BaseClass
    {
      //[Key]
      //public int Id { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public int UserId { get; set; } // Foreign Key → User

        [Required]
      [Display(Name = "Company ID")]
      public int CompanyId { get; set; } // Foreign Key → CompanyProfile

      [Required]
      [StringLength(25)]
      [Display(Name = "Full Name")]
      public string FullName { get; set; } = string.Empty;

      [Display(Name = "Recruiter Subscription ID")]
      public int RecruiterSubscriptionId { get; set; } // Foreign Key → RecruiterSubscription

      [Required]
      [Display(Name = "Recruiter Role")]
    // public RecruiterRole RecruiterRole { get; set; } //Enum

//     public virtual User? User { get; set; }
      public virtual CompanyProfile? CompanyProfile { get; set; }
      public virtual RecruiterSubscription? RecruiterSubscription { get; set; }


   

        //public int Id { get; set; } // Primary Key
        //public int UserId { get; set; } // Foreign Key -> User
        //public int CompanyId { get; set; } // Foreign Key -> CompanyProfile
        //public string FullName { get; set; }
        //public int RecruiterSubscriptionID { get; set; } // Foreign Key -> RecruiterSubscription
        //public RecruiterRole RecruiterRole { get; set; } // Enum

        //// Navigation properties
        //public virtual User User { get; set; }
        //public virtual CompanyProfile CompanyProfile { get; set; }
        //public virtual RecruiterSubscription RecruiterSubscription { get; set; }
        public virtual ICollection<JobPost> JobPosts { get; set; }

    }
}