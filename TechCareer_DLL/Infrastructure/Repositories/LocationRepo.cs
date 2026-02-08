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
    public interface ILocationRepo : IGenericRepo<Location>
    {
    }
    public class LocationRepo : GenericRepo<Location>, ILocationRepo
    {
        public LocationRepo(JobContext context) : base(context)
        {
        }
    }
}
