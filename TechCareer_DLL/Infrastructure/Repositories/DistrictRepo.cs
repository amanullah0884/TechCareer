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
    public interface IDistrictRepo :  IGenericRepo<District>
    {
    }
    public class DistrictRepo : GenericRepo<District>, IDistrictRepo
    {
        public DistrictRepo(JobContext context) : base(context)
        {
        }
    }
}
