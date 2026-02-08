using TechCareer_DLL.Models.Enums;
using TechCareer_DLL.Models.Recruiters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace TechCareer_DLL.Models.BillingInformation
{
   public class RecruiterSubscription: BaseClass
    {
        //[Key]
        //public int Id { get; set; }

        [ForeignKey(nameof(Recruiter))]
        public int RecruiterId { get; set; } // Foreign Key -> Recruiter

        [ForeignKey(nameof(RecruiterPackage))]
        public int PackageId { get; set; }

        [Required]
      [Display(Name = "Subscription Date")]
      public DateTime SubscriptionDate { get; set; } = DateTime.Now;

      [Required]
      [Range(0, double.MaxValue, ErrorMessage = "Amount must be positive.")]
      [Display(Name = "Amount (BDT)")]
      public decimal Amount { get; set; }

      [Required]
      [Display(Name = "Payment Status")]
      public PaymentStatus PaymentStatus { get; set; }

      [Required]
      [Range(1, 36, ErrorMessage = "Duration must be between 1 and 36 months.")]
      [Display(Name = "Duration (in Months)")]
      public int DurationInMonth { get; set; }

      // Navigation properties
      public virtual Recruiter? Recruiter { get; set; }

      [Display(Name = "Package")]
      public virtual RecruiterPackage? RecruiterPackage { get; set; }

      public virtual ICollection<Transaction>? Transactions { get; set; }
   }

}
