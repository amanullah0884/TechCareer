using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Recruiters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Repositories
{
   public interface ICompanyRepo:IGenericRepo<CompanyProfile>
    {

    }
    public class CompanyRepo : GenericRepo<CompanyProfile>, ICompanyRepo
    {
        public CompanyRepo(JobContext context) : base(context)
        {
        }
    }
  
}
