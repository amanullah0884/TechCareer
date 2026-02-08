using TechCareer_DLL.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.SiteSettings
{
    public class Notification: BaseClass
    {
        //public int Id { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key -> User
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RelationType { get; set; } // SiteOwner -> JobSeeker, Recruiter -> Jobseeker

        // Navigation properties
        public virtual User User { get; set; }
    }
}
