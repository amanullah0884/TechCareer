using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.SiteSettings.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Repositories
{
    public interface IDivisionRepo : IGenericRepo<Division>
    {
    }
    public class DivisionRepo : GenericRepo<Division>, IDivisionRepo
    {
        public DivisionRepo(JobContext  context) : base(context)
        {
        }
    
    }
}
