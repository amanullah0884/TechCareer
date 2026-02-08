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
    public interface ICountryRepo : IGenericRepo<Country>
    {

    }
    public class CountryRepo : GenericRepo<Country>, ICountryRepo
    {
        public CountryRepo(JobContext context) : base(context)
        {
        }
    }
    
}
