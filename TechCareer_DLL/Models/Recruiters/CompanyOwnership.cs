using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.Recruiters
{
    public class CompanyOwnership:BaseClass
    {
        //public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Type { get; set; } // public/private/govt

        // Navigation properties
        public virtual ICollection<CompanyProfile> CompanyProfiles { get; set; }
    }
}
