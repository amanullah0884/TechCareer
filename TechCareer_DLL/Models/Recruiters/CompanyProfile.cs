using System.ComponentModel.DataAnnotations;

namespace TechCareer_DLL.Models.Recruiters
{
  public  class CompanyProfile:BaseClass
    {
        // public int Id { get; set; }
        [StringLength(30, ErrorMessage = "Company name cannot be longer than 30 characters.")]
        public string CompanyName { get; set; } = string.Empty;
        [StringLength(100, ErrorMessage = "Description cannot be longer than 100 characters.")]
        public string Description { get; set; } = string.Empty;
        [StringLength(15, ErrorMessage = "Contact info cannot be longer than 15 characters.")]
        public string ContactInfo { get; set; } = string.Empty;
        [StringLength(100, ErrorMessage = "Website cannot be longer than 100 characters.")]
        public string Website { get; set; } = string.Empty;
        public string CompanyLogoPath { get; set; } = string.Empty;
        public bool VerificationStatus { get; set; } = false;
        [StringLength(200, ErrorMessage = "Verification note cannot be longer than 200 characters.")]
        public string VerificationNote { get; set; } = string.Empty;
    }
}
