using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.SiteSettings.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Repositories
{
    public interface IDegreeOrExamRepo : IGenericRepo<DegreeOrExam>
    {
    }
    public class DegreeOrExamRepo : GenericRepo<DegreeOrExam>, IDegreeOrExamRepo
    {
        public DegreeOrExamRepo(JobContext context) : base(context)
        {
        }
    }
   
    
}
