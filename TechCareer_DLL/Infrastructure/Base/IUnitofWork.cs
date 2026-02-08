using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Repositories;
using TechCareer_DLL.Models;
using TechCareer_DLL.Models.BillingInformation;
using TechCareer_DLL.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Base
{
   public interface IUnitofWork:IDisposable
    {
        ModelMessage Save();
      Task SaveAsync();

      // Task SaveAsync();
      //Recruiter Repos
      public ICompanyRepo CompanyRepo { get; }
      public ICompanyOwnershipRepo CompanyOwnershipRepo { get; }
      public IJobNatureRepo JobNatureRepo { get; }
      public IJobPostRepo JobPostRepo { get; }
      public IJobRequiredSkillRepo JobRequiredSkillRepo { get; }
      public  IRecruiterRepo RecruiterRepo { get; }
      public IPreferredJobInfoRepo PreferredJobInfoRepo { get; }


        // public ICompanyProfileRepo CompanyProfileRepo { get; }
        //public ICompanyRepo CompanyRepo { get; }
       
       public IJobSeekerExperienceRepo JobSeekerExperienceRepo { get; }

        //Site Settings Repos
        public IJobCategoryRepo JobCategoryRepo { get; }
        public ICountryRepo CountryRepo { get; }
        public IDivisionRepo DivisionRepo { get; }
        public IDistrictRepo DistrictRepo { get; }
        public ILocationRepo LocationRepo { get; }
        public IAreaRepo AreaRepo { get; }
        public INotificationRepo NotificationRepo { get; }
        public ISkillsRepo  SkillsRepo { get; }
        public IInstitutionRepo InstitutionRepo { get; }
        public ILevelOfEducationRepo LevelOfEducationRepo { get; }
        public IDegreeOrExamRepo DegreeOrExamRepo { get; }
        //Billinginformation Repos
        public IPaymentMethodRepo PaymentMethodRepo { get; }
        public IPaymentTransactionRepo paymentTransactionRepo { get; }
        public IRecruiterPackageRepo RecruiterPackageRepo { get; }
        public IRecruiterSubscriptionRepo RecruiterSubscriptionRepo { get; }
        //JobSeeker Repos U
        //shawon start
        public ISocialMediaRepo SocialMediaRepo { get; }
        public IResumeRepo ResumeRepo { get; }
        public IJobSeekersSocialMediaRepo JobSeekersSocialMediaRepo { get; }
        public IJobSeekerSkillRepo JobSeekerSkillRepo { get; }
        //public IJobSeekerRepo JobSeekerRepo { get; }
        public ICareerEventRepo CareerEventRepo { get; }
        public IJobSeekersKeywordRepo JobSeekersKeywordRepo { get; }
       public IJobSeekerCertificateRepo JobSeekerCertificateRepo { get; }
        //shawon End
      //Umme
      public ICareerInformationRepo CareerInformationRepo { get; }
      public IJobSeekerInfoRepo JobSeekerInfoRepo { get; }
      public IJobApplicationRepo JobApplicationRepo { get; }
      public IJobSeekerEducationRepo JobSeekerEducationRepo { get; }
      public IJobSeekerTrainingRepo JobSeekerTrainingRepo { get; }

      public IJobSeekerAchievementRepo JobSeekerAchievementRepo { get; }
      public IPersonalInformationRepo PersonalInformationRepo { get; }
      public IJobSeekerRepo JobSeekerRepo { get; }

      public ISavedJobsRepo SavedJobsRepo { get; }
        
    }
    public class UnitofWork : IUnitofWork
    {
        private readonly JobContext _context;
        public UnitofWork(JobContext context) {
            this._context = context;
        }
        public ModelMessage Save()
        {
            ModelMessage modelMessage = new ModelMessage();
            try
            {
                if (_context.SaveChanges() > 0)
                {
                    modelMessage.Message = $"Operation Successfull";
                    modelMessage.IsSuccess = true;
                }
                else
                {
                    modelMessage.Message = $"Operation Failled";
                    modelMessage.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {

                modelMessage.Message = ex.InnerException?.Message ?? ex.Message;
                modelMessage.IsSuccess = false;

            }
            return modelMessage;
        }




        #region Recruiter Repos

        private ICompanyRepo companyRepo;
        public ICompanyRepo CompanyRepo
        {
            get
            {
                if (companyRepo == null)
                {
                    companyRepo = new CompanyRepo(_context);
                }
                return companyRepo;
            }
        }

        private ICompanyOwnershipRepo companyOwnershipRepo;
        public ICompanyOwnershipRepo CompanyOwnershipRepo
        {
            get
            {
                if (companyOwnershipRepo == null)
                {
                    companyOwnershipRepo = new CompanyOwnershipRepo(_context);
                }
                return companyOwnershipRepo;
            }
        }
        private IJobNatureRepo jobNatureRepo;
        public IJobNatureRepo JobNatureRepo
        {
            get
            {
                if (jobNatureRepo == null)
                {
                    jobNatureRepo = new JobNatureRepo(_context);
                }
                return jobNatureRepo;
            }
        }
        private IJobPostRepo jobPostRepo;
        public IJobPostRepo JobPostRepo
        {
            get
            {
                if (jobPostRepo == null)
                {
                    jobPostRepo = new JobPostRepo(_context);
                }
                return jobPostRepo;
            }
        }
        private IJobRequiredSkillRepo jobRequiredSkillrepo;
        public IJobRequiredSkillRepo JobRequiredSkillRepo
        {
            get
            {
                if (jobRequiredSkillrepo == null)
                {
                    jobRequiredSkillrepo = new JobRequiredSkillRepo(_context);
                }
                return jobRequiredSkillrepo;
            }
        }
        private IRecruiterRepo recruiterRepo;
        public IRecruiterRepo RecruiterRepo
        {
            get
            {
                if (recruiterRepo == null)
                {
                    recruiterRepo = new RecruiterRepo(_context);
                }
                return recruiterRepo;
            }
        }

        #endregion
        //BillingInformation repo U
        private IPaymentMethodRepo paymentMethodRepo;
        public IPaymentMethodRepo PaymentMethodRepo
        {
            get
            {
                if (paymentMethodRepo == null)
                {
                    paymentMethodRepo = new PaymentMethodRepo(_context);
                }
                return paymentMethodRepo;
            }
        }
        private IPaymentTransactionRepo PaymentTransactionRepo;
        public IPaymentTransactionRepo paymentTransactionRepo
        {
            get
            {
                if (PaymentTransactionRepo == null)
                {
                    PaymentTransactionRepo = new PaymentTransactionRepo(_context);
                }
                return paymentTransactionRepo;
            }
        }
        private IRecruiterPackageRepo recruiterPackageRepo;
        public IRecruiterPackageRepo RecruiterPackageRepo
        {
            get
            {
                if (recruiterPackageRepo == null)
                {
                    recruiterPackageRepo = new RecruiterPackageRepo(_context);
                }
                return recruiterPackageRepo;
            }
        }
        private IRecruiterSubscriptionRepo _recruiterSubscriptionRepo;

        public IRecruiterSubscriptionRepo RecruiterSubscriptionRepo
        {
            get
            {
                if (_recruiterSubscriptionRepo == null)
                {
                    _recruiterSubscriptionRepo = new RecruiterSubscriptionRepo(_context);
                }
                return _recruiterSubscriptionRepo;
            }
        }
        //JobSeeker repo U
        private IJobSeekerAchievementRepo jobSeekerAchievementRepo;

        public IJobSeekerAchievementRepo JobSeekerAchievementRepo
        {
            get
            {
                if (jobSeekerAchievementRepo == null)
                {
                    jobSeekerAchievementRepo = new JobSeekerAchievementRepo(_context);
                }
                return jobSeekerAchievementRepo;
            }
        }
        private IPersonalInformationRepo personalInformationRepo;

        public IPersonalInformationRepo PersonalInformationRepo
        {
            get
            {
                if (personalInformationRepo == null)
                {
                    personalInformationRepo = new PersonalInformationRepo(_context);
                }
                return personalInformationRepo;
            }
        }


        //   private ICompanyProfileRepo companyProfileRepo;
        //   public ICompanyProfileRepo CompanyProfileRepo
        //{
        //         get
        //         {
        //            if (companyProfileRepo == null)
        //            {
        //               companyProfileRepo = new CompanyProfileRepo(_context);
        //            }
        //            return companyProfileRepo;
        //   }

        //Site Settings Repos
        private IJobCategoryRepo jobCategoryRepo;
        public IJobCategoryRepo JobCategoryRepo
        {
            get
            {
                if (jobCategoryRepo == null)
                {
                    jobCategoryRepo = new JobCategoryRepo(_context);
                }
                return jobCategoryRepo;
            }
        }

        private ICountryRepo countryRepo;
        public ICountryRepo CountryRepo
        {
            get
            {
                if (countryRepo == null)
                {
                    countryRepo = new CountryRepo(_context);
                }
                return countryRepo;
            }
        }
        private IDivisionRepo divisionRepo;
        public IDivisionRepo DivisionRepo
        {
            get
            {
                if (divisionRepo == null)
                {
                    divisionRepo = new DivisionRepo(_context);
                }
                return divisionRepo;
            }
        }
        private IDistrictRepo districtRepo;
        public IDistrictRepo DistrictRepo
        {
            get
            {
                if (districtRepo == null)
                {
                    districtRepo = new DistrictRepo(_context);
                }
                return districtRepo;
            }
        }
        private ILocationRepo locationRepo;
        public ILocationRepo LocationRepo
        {
            get
            {
                if (locationRepo == null)
                {
                    locationRepo = new LocationRepo(_context);
                }
                return locationRepo;
            }
        }
        private IAreaRepo areaRepo;
        public IAreaRepo AreaRepo
        {
            get
            {
                if (areaRepo == null)
                {
                    areaRepo = new AreaRepo(_context);
                }
                return areaRepo;
            }
        }

        private INotificationRepo notificationRepo;
        public INotificationRepo NotificationRepo
        {
            get
            {
                if (notificationRepo == null)
                    {
                    notificationRepo = new NotificationRepo(_context);
                }
                return notificationRepo;
            }
        }

        private ISkillsRepo skillsRepo;
        public ISkillsRepo SkillsRepo
        {
            get 
            {
                if (skillsRepo == null)
                {
                    skillsRepo = new SkillsRepo(_context);
                }
                return skillsRepo;
            }

        }
        private IInstitutionRepo institutionRepo;
        public IInstitutionRepo InstitutionRepo
        {
            get
            {
                if (institutionRepo == null)
                {
                    institutionRepo = new InstitutionRepo(_context);
                }
                return institutionRepo;
            }
        }
        private ILevelOfEducationRepo levelOfEducationRepo;
        public ILevelOfEducationRepo LevelOfEducationRepo
        {
            get
            {
                if (levelOfEducationRepo == null)
                {
                    levelOfEducationRepo = new LevelOfEducationRepo(_context);
                }
                return levelOfEducationRepo;
            }
        }
       private IDegreeOrExamRepo degreeOrExamRepo;
        public IDegreeOrExamRepo DegreeOrExamRepo
        {
            get
            {
                if (degreeOrExamRepo == null)
                {
                    degreeOrExamRepo = new DegreeOrExamRepo(_context);
                }
                return degreeOrExamRepo;
            }
        }
        private IJobSeekerExperienceRepo jobSeekerExperienceRepo;
        public IJobSeekerExperienceRepo JobSeekerExperienceRepo
        {
            get
            {
                if (jobSeekerExperienceRepo == null)
                {
                    jobSeekerExperienceRepo = new JobSeekerExperienceRepo(_context);
                }
                return jobSeekerExperienceRepo;
            }
        }
        //shawon  jobseeker start
        private ISocialMediaRepo mediaRepo;
        public ISocialMediaRepo SocialMediaRepo
        {
            get
            {
                if (mediaRepo==null) {
                
                mediaRepo= new SocialMediaRepo(_context);
                }
                return mediaRepo;   


            }
        }


        private IJobSeekersKeywordRepo jobSeekersKeywordRepo;
        public IJobSeekersKeywordRepo JobSeekersKeywordRepo{
            get{
                if (jobSeekersKeywordRepo == null)
                { 
                 jobSeekersKeywordRepo= new JobSeekersKeywordRepo(_context);
                }
                return jobSeekersKeywordRepo;

                }
            
            }
        public IResumeRepo resumeRepo;
        public IResumeRepo ResumeRepo
        {
            get
            {
                if (resumeRepo==null)
                {
                    resumeRepo= new ResumeRepo(_context);


                }
                return resumeRepo;
            }

        }

        private IJobSeekerSkillRepo jobSeekersSkillRepo;
        public IJobSeekerSkillRepo JobSeekerSkillRepo
        {
            get {
                if (jobSeekersSkillRepo == null)
                {
                    jobSeekersSkillRepo=new JobSeekerSkillRepo(_context);

                }
            return jobSeekersSkillRepo ;
            }
        }
        //private IJobSeekerRepo jobSeekerRepo;
        //public IJobSeekerRepo JobSeekerRepo
        //{
        //    get
        //    {
        //        if (jobSeekerRepo == null)
        //        {

        //            jobSeekerRepo = new JobSeekerRepo(_context);
        //        }
        //        return jobSeekerRepo;
        //    }
        //}
        private IJobSeekersSocialMediaRepo jobSeekersSocialMediaRepo;
        public IJobSeekersSocialMediaRepo JobSeekersSocialMediaRepo
        {
            get {

                if (jobSeekersSocialMediaRepo == null) { 
                
                jobSeekersSocialMediaRepo=new JobSeekersSocialMediaRepo(_context);
                }
                return JobSeekersSocialMediaRepo ;
            
            }
            

        }


        private IJobSeekerCertificateRepo jobSeekerCertificateRepo;
        public IJobSeekerCertificateRepo JobSeekerCertificateRepo
        {
            get
            {
                if (jobSeekerCertificateRepo == null)
                {
                    jobSeekerCertificateRepo = new JobSeekerCerificateRepo(_context);
                }
                return jobSeekerCertificateRepo;


            }
        }
        private ICareerEventRepo careerEventRepo;
        public ICareerEventRepo CareerEventRepo
        {
            get
            {
                if (careerEventRepo == null)
                {
                    careerEventRepo = new CareerEventRepo(_context);
                }
                return careerEventRepo;
            }
        }
        //Jobseeker End
        // Umme
        private ICareerInformationRepo careerInformationRepo;
      public ICareerInformationRepo CareerInformationRepo
      {
         get
         {
            if(careerInformationRepo == null)
            {
               careerInformationRepo = new CareerInformationRepo(_context);
            }
            return careerInformationRepo;
         }
      }


      private IJobSeekerInfoRepo jobSeekerInfoRepo;
      public IJobSeekerInfoRepo JobSeekerInfoRepo
      {
         get
         {
            if(jobCategoryRepo == null)
            {
               jobCategoryRepo = new JobCategoryRepo(_context);
            }
            return jobSeekerInfoRepo;
         }
      }


      private IJobApplicationRepo jobApplicationRepo;
      public IJobApplicationRepo JobApplicationRepo
      {
         get
         {
            if(jobApplicationRepo == null)
            {
               jobApplicationRepo = new JobApplicationRepo(_context);
            }
            return jobApplicationRepo;
         }
      }


      private IJobSeekerEducationRepo jobSeekerEducationRepo;
      public IJobSeekerEducationRepo JobSeekerEducationRepo
      {
         get
         {
            if (jobSeekerEducationRepo == null)
            {
               jobSeekerEducationRepo = new JobSeekerEducationRepo(_context);
            }
            return jobSeekerEducationRepo;
         }
      }


      //uddipon

      private IJobSeekerTrainingRepo jobSeekerTrainingRepo;
      public IJobSeekerTrainingRepo JobSeekerTrainingRepo
      {
         get
         {
            if(jobSeekerTrainingRepo == null)
            {
               jobSeekerTrainingRepo = new JobSeekerTrainingRepo(_context);
            }
            return jobSeekerTrainingRepo;

         }
      }


      private IPreferredJobInfoRepo preferredJobInfoRepo;
      public IPreferredJobInfoRepo PreferredJobInfoRepo
      {
         get
         {
            if(preferredJobInfoRepo == null)
            {
               preferredJobInfoRepo = new PreferredJobInfoRepo(_context);
            }
            return preferredJobInfoRepo;
         }
      }

      private IJobSeekerRepo jobSeekerRepo;
      public IJobSeekerRepo JobSeekerRepo
      {
         get
         {
            if( jobSeekerRepo == null)
            {
               jobSeekerRepo = new JobSeekerRepo(_context);
            }
            return jobSeekerRepo;
         }
      }

      public ISavedJobsRepo savedJobsRepo;
      public ISavedJobsRepo SavedJobsRepo
      {
         get
         {
            if(savedJobsRepo == null)
            {
               savedJobsRepo = new SavedJobsRepo(_context);
            }
            return savedJobsRepo;
         }
      }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

      public async Task SaveAsync()
      {
          await _context.SaveChangesAsync();
       //  return (result);
      }

   }
}
