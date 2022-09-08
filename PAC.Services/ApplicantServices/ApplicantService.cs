using PAC.Data.Employees.Applicants;
using PAC.Data.Employees.Applicants.Applicant_References;
using PAC.Data.Employees.Applicants.References;
using PAC.Models.ApplicantModels;
using PAC.Models.DepartmentModels.Department_Positions;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.ApplicantServices
{
    public class ApplicantService
    {
       // private Guid _userId;
        //public ApplicantService(Guid userId)
        //{
        //    _userId = userId;
        //}
        public async Task<bool> CreateApplicantAsync(ApplicantCreate applicant)
        {
            var entity = new Applicant
            {
                OwnerID = Guid.NewGuid(),
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                EmailAddress=applicant.EmailAddress,
                SocialSecurityNumber = applicant.SocialSecurityNumber,
                Address = applicant.Address,
                DepartmentID = applicant.DepartmentID,
                CompanyAReferenceFirstName=applicant.CompanyAReferenceFirstName,
                CompanyAReferenceLastName=applicant.CompanyAReferenceLastName,
                CompanyAName=applicant.CompanyAName,
                CompanyAMayWeContactThisEmployer=applicant.CompanyAMayWeContactThisEmployer,
                CompanyAAddress=applicant.CompanyAAddress,
                CompanyADateStarted=applicant.CompanyADateStarted,
                CompanyADateEnded=applicant.CompanyADateEnded,
                CompanyBName=applicant.CompanyBName,
                CompanyBReferenceFirstName=applicant.CompanyBReferenceFirstName,
                CompanyBReferenceLastName=applicant.CompanyBReferenceLastName,
                CompanyBAddress=applicant.CompanyBAddress,
                CompanyBDateStarted=applicant.CompanyBDateStarted,
                CompanyBDateEnded=applicant.CompanyBDateEnded,
                CompanyBMayWeContactThisEmployer=applicant.CompanyBMayWeContactThisEmployer,
                CompanyCName=applicant.CompanyCName,
                CompanyCReferenceFirstName=applicant.CompanyCReferenceFirstName,
                CompanyCReferenceLastName=applicant.CompanyCReferenceLastName,
                CompanyCAddress=applicant.CompanyCAddress,
                CompanyCDateStarted=applicant.CompanyCDateStarted,
                CompanyCDateEnded=applicant.CompanyCDateEnded,
                CompanyCMayWeContactThisEmployer=applicant.CompanyCMayWeContactThisEmployer,
            };

         
            using (var ctx = new ApplicationDbContext())
            {
                //var user = await ctx.Users.SingleOrDefaultAsync(u=>u.Email==applicant.EmailAddress);
                //if (user is null)
                //{
                //    return false;
                //}
                //entity.EmailAddress = user.Email;
                ctx.Applicants.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> UpdateApplicantDataAsync(ApplicantEdit applicant, int applicantID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldApplicantData = await ctx.Applicants.FindAsync(applicantID);
                if (oldApplicantData is null)
                {
                    return false;
                }
                oldApplicantData.FirstName = applicant.FirstName;
                oldApplicantData.LastName = applicant.LastName;
                oldApplicantData.EmailAddress = applicant.EmailAddress;
                oldApplicantData.SocialSecurityNumber = applicant.SocialSecurityNumber;
                oldApplicantData.Address = applicant.Address;
                oldApplicantData.DepartmentID = applicant.DepartmentID;

                return await ctx.SaveChangesAsync() > 0;

            }
        }
        public async Task<bool> DeleteApplicantDataAsync(int applicantID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var application = await ctx.Applicants.FindAsync(applicantID);
                if (application is null)
                {
                    return false;
                }
                ctx.Applicants.Remove(application);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<ApplicantDetail> GetApplicantByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var applicant = await
                    ctx
                    .Applicants
                    .Include(d => d.Department.Department_Positions)
                    // .Where(a => a.OwnerID == _userId)
                    .SingleOrDefaultAsync(a => a.ID == id);
                if (applicant is null)
                {
                    return null;
                }
                return new ApplicantDetail
                {
                    ID = applicant.ID,
                    FirstName = applicant.FirstName,
                    LastName = applicant.LastName,
                    EmailAddress=applicant.EmailAddress,
                    SocialSecurityNumber = applicant.SocialSecurityNumber,
                    Address = applicant.Address,
                    DepartmentID = applicant.DepartmentID,
                    DepartmentName = applicant.Department.Name,
                    CompanyAName = applicant.CompanyAName,
                    CompanyAReferenceFirstName = applicant.CompanyAReferenceFirstName,
                    CompanyAReferenceLastName = applicant.CompanyAReferenceLastName,
                    CompanyAAddress = applicant.CompanyAAddress,
                    CompanyADateStarted = applicant.CompanyADateStarted,
                    CompanyADateEnded = applicant.CompanyADateEnded,
                    CompanyAMayWeContactThisEmployer = applicant.CompanyAMayWeContactThisEmployer,
                    CompanyBName = applicant.CompanyBName,
                    CompanyBReferenceFirstName = applicant.CompanyBReferenceFirstName,
                    CompanyBReferenceLastName = applicant.CompanyBReferenceLastName,
                    CompanyBAddress = applicant.CompanyBAddress,
                    CompanyBDateStarted = applicant.CompanyBDateStarted,
                    CompanyBDateEnded = applicant.CompanyBDateEnded,
                    CompanyBMayWeContactThisEmployer = applicant.CompanyBMayWeContactThisEmployer,
                    CompanyCName = applicant.CompanyCName,
                    CompanyCReferenceFirstName = applicant.CompanyCReferenceFirstName,
                    CompanyCReferenceLastName = applicant.CompanyCReferenceLastName,
                    CompanyCAddress = applicant.CompanyCAddress,
                    CompanyCDateStarted = applicant.CompanyCDateStarted,
                    CompanyCDateEnded = applicant.CompanyCDateEnded,
                    CompanyCMayWeContactThisEmployer = applicant.CompanyCMayWeContactThisEmployer
                };
            }
        }
        public async Task<ApplicantDetail> GetApplicantByEmail(string email)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user = await ctx.Users.ToListAsync();
                string userData=null;
                foreach (var item in user)
                {
                    if (item.Email.Contains(email))
                    {
                        userData = item.Email;
                    }
                }
                if (user is null)
                {
                    return null;
                }
                var query = await
                    ctx
                    .Applicants
                    .Include(d => d.Department.Department_Positions)
                    // .Where(a => a.OwnerID == _userId)
                    .SingleOrDefaultAsync(a => a.EmailAddress == userData);
                if (query is null)
                {
                    return null;
                }
                return new ApplicantDetail
                {
                    ID = query.ID,
                    FirstName = query.FirstName,
                    LastName = query.LastName,
                    SocialSecurityNumber = query.SocialSecurityNumber,
                    Address = query.Address,
                    EmailAddress=query.EmailAddress,
                    DepartmentID = query.DepartmentID,
                    DepartmentName = query.Department.Name,
                    CompanyAName = query.CompanyAName,
                    CompanyAReferenceFirstName = query.CompanyAReferenceFirstName,
                    CompanyAReferenceLastName = query.CompanyAReferenceLastName,
                    CompanyAAddress = query.CompanyAAddress,
                    CompanyADateStarted = query.CompanyADateStarted,
                    CompanyADateEnded = query.CompanyADateEnded,
                    CompanyAMayWeContactThisEmployer = query.CompanyAMayWeContactThisEmployer,
                    CompanyBName = query.CompanyBName,
                    CompanyBReferenceFirstName = query.CompanyBReferenceFirstName,
                    CompanyBReferenceLastName = query.CompanyBReferenceLastName,
                    CompanyBAddress = query.CompanyBAddress,
                    CompanyBDateStarted = query.CompanyBDateStarted,
                    CompanyBDateEnded = query.CompanyBDateEnded,
                    CompanyBMayWeContactThisEmployer = query.CompanyBMayWeContactThisEmployer,
                    CompanyCName = query.CompanyCName,
                    CompanyCReferenceFirstName = query.CompanyCReferenceFirstName,
                    CompanyCReferenceLastName = query.CompanyCReferenceLastName,
                    CompanyCAddress = query.CompanyCAddress,
                    CompanyCDateStarted = query.CompanyCDateStarted,
                    CompanyCDateEnded = query.CompanyCDateEnded,
                    CompanyCMayWeContactThisEmployer = query.CompanyCMayWeContactThisEmployer
                };
            }
        }
        public async Task<bool> UpdateApplicantDataViaEmailAsync(ApplicantEdit applicant, string email)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldApplicantData = await ctx.Applicants.ToListAsync();

                Applicant applicantData=new Applicant();
                foreach (var item in oldApplicantData)
                {
                    if (item.EmailAddress.Contains(email))
                    {
                        applicantData = item;
                    }
                }
                //if (applicantData is null)
                //{
                //    return false;
                //}
                applicantData.FirstName = applicant.FirstName;
                applicantData.LastName = applicant.LastName;
                applicantData.EmailAddress = applicant.EmailAddress;
                applicantData.SocialSecurityNumber = applicant.SocialSecurityNumber;
                applicantData.Address = applicant.Address;
                applicantData.DepartmentID = applicant.DepartmentID;

                return await ctx.SaveChangesAsync() > 0;

            }
        }
        
    }
}
