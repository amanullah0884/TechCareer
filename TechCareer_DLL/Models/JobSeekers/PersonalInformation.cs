using TechCareer_DLL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
    public class PersonalInformation:BaseClass
    {
        //public int JobSeekerInformationId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }= string.Empty;
        public string FathersName { get; set; }= string.Empty;
        public string MothersName { get; set; }= string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Religion Religion { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string Nationality { get; set; }= string.Empty;
        public int NationalIdNumber { get; set; }
        public string PassportNumber { get; set; }= string.Empty;
        public string PrimaryPhoneNumber { get; set; }= string.Empty;
        public string SecondaryPhoneNumber { get; set; }= string.Empty;
        public string PrimaryEmail { get; set; }= string.Empty;
        public string SecondaryEmail { get; set; }= string.Empty;
        public BloodGroup BloodGroup { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
    }
}
