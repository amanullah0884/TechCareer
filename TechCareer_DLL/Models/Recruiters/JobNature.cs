using TechCareer_DLL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.Recruiters
{
    public class JobNature: BaseClass
    {
        //public int Id { get; set; } // Primary Key
        public JobNatureCategory JobNatureCategory { get; set; } // Enum

        // Navigation properties
        public virtual ICollection<JobPost> JobPosts { get; set; }
    }

}
    