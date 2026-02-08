using TechCareer_DLL.Models.Enums;
using TechCareer_DLL.Models.JobSeekers;
using TechCareer_DLL.Models.Recruiters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.Person
{
    public class User: BaseClass
    {
        //public int Id { get; set; } // Primary Key
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public UserType UserType { get; set; } // Enum
        public bool IsVerified { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLoginAt { get; set; }

        // Navigation properties
        
        public virtual JobSeekerInformation JobSeekerInformation { get; set; }
        public virtual Recruiter Recruiter { get; set; }
    }

}
