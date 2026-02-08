using TechCareer_DLL.Models.JobSeekers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.SearchKeyword
{
    public class SearchKeywords: BaseClass
    {
        //public int Id { get; set; } // Primary Key
        public string Keyword { get; set; }

        // Navigation properties
        public virtual ICollection<JobSeekersKeyword> JobSeekersKeywords { get; set; }

    }
}
