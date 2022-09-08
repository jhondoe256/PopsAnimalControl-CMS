using PAC.Data.Employees;
using PAC.Data.HumanResource_s.HiredEmployee_s;
using PAC.Models.ApplicantModels;
using PAC.Models.HiredEmployeeModels;
using PAC.Services.ApplicantServices;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.HiredEmployeeServices
{
    //HUMAN RESOURCES/Admin AUTORIZATION ONLY
    public class HumanResourceHub_Service
    {
        private const int _dogCatcherDepartment = 1;
        private const int _catCatcherDepartment = 2;
        private const int _pokemonCatcherDepartment = 3;
        private const int _humanResourcesDepartment = 5;
        private readonly Guid _userId;
        public HumanResourceHub_Service(Guid userId)
        {
            _userId = userId;
        }

        public HumanResourceHub_Service()
        {

        }
        //This Method automates the hiring of an employee... I don't think its useable for the app.....Maybe?
        public async Task<bool> AssignApplicantToDepartment(AddEmployeeToDepartment employeeInfo)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var applicant = await ctx.Applicants.FindAsync(employeeInfo.ApplicantID);
                if (applicant is null)
                {
                    return false;
                }

                //map applicant to employee
                var employeeApplicant = new Employee
                {
                    FirstName = applicant.FirstName,
                    LastName = applicant.LastName,
                };


                var department = await ctx.Departments.FindAsync(employeeInfo.DepartmentID);
                if (department is null)
                {
                    return false;
                }

                var position = await ctx.Positions.FindAsync(employeeInfo.PositionID);
                if (position is null)
                {
                    return false;
                }

                var entity = new HiredEmployee
                {
                    //  OwnerID = _userId,
                    FirstName = employeeApplicant.FirstName,
                    LastName = employeeApplicant.LastName,
                    Position = position,
                    EmployeeDateOfHire = DateTime.Now,
                    CreationDate = DateTime.Now
                };

                var employeeData = new Employee
                {
                    //   OwnerID = _userId,
                    FirstName = employeeApplicant.FirstName,
                    LastName = employeeApplicant.LastName,
                    Position = position,
                    CreationDate = DateTime.Now
                };
                //Guinevere Beck
                //USER ROLES HAVE TO BE ADDED HERE AS WELL!!!!!
                if (position.AvailablePositionCount > 0)
                {
                    ctx.Employees.Add(employeeData);
                    department.Employees.Add(entity);
                    entity.DepartmentID = department.ID;
                    position.AvailablePositionCount--;
                    ctx.Applicants.Remove(applicant);
                    return await ctx.SaveChangesAsync() > 0;
                }

                return false;
            }
        }
        public async Task<bool> AssignEmployeeToDifferentDepartment(AssignEmployeeToDifferentDepartment employeeInfo, int positionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var employee = await ctx.Employees.FindAsync(employeeInfo.EmployeeID);

                if (employee is null)
                {
                    return false;
                }

                //caching the inital employeeDepartment
                var initialEmployeeDepartment = ctx.Departments.SingleOrDefaultAsync(d => d.ID == employee.Position.DepartmentID);

                //THIS IS THE DEPARTMENT THAT THE EMPLOYEE IS BEING REASSIGNED TO 
                var department = await ctx.Departments.FindAsync(employeeInfo.DepartmentID);

                if (department is null)
                {
                    return false;
                }

                //THE INITIAL POSITION THAT HAS BEEN ASSIGNED TO THE EMPLOYEE
                var employeePosition = await ctx.Positions.SingleOrDefaultAsync(p => p.PositionID == positionID);

                if (employeePosition is null)
                {
                    return false;
                }

                //NEED TO CHANGE USER ROLE IN THIS AREA......

                employee.Position = employeePosition;

                initialEmployeeDepartment.Result.Employees.Remove(employee);

                employee.Position.Department = department;

                //THIS SIMULATES THE RE-OPENING OF ANOTHER POSITION W/N THE DATABASE-- INCREASING THE COUNT
                employee.Position.AvailablePositionCount++;
                //     employeePosition.AvailablePositionCount--;

                employee.Position = await ctx.Positions.SingleOrDefaultAsync(p => p.PositionID == employeeInfo.PositionID);

                department.Employees.Add(employee);

                return await ctx.SaveChangesAsync() > 0;

            }
        }
        public async Task<IEnumerable<ApplicantListItem>> GetApplicantsAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query = await
                    ctx
                    .Applicants
                    // .Where(a => a.OwnerID == _userId)
                    .Select(a => new ApplicantListItem
                    {
                        ID = a.ID,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        DepartmentOfIntrest = a.Department.Name
                    }).ToListAsync();
                return query;
            }
        }
        public async Task<ApplicantDetail> GetApplicantDetailAsync(int applicantId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                    ctx
                    .Applicants
                    .Include(d => d.Department.Department_Positions)
                    // .Where(a => a.OwnerID == _userId)
                    .SingleOrDefaultAsync(a => a.ID == applicantId);
                if (query is null)
                {
                    return null;
                }
                return new ApplicantDetail
                {
                    ID = query.ID,
                    FirstName = query.FirstName,
                    LastName = query.LastName,
                    EmailAddress = query.EmailAddress,
                    SocialSecurityNumber = query.SocialSecurityNumber,
                    Address = query.Address,
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
        public async Task<List<ApplicantListItem>> GetDogCatcherApplicants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var applicants = await
                    ctx
                    .Applicants
                    .Where(a => a.DepartmentID == _dogCatcherDepartment)
                    .Select(a => new ApplicantListItem()
                    {
                        ID=a.ID,
                        FirstName=a.FirstName,
                        LastName=a.LastName,
                        DepartmentID=a.DepartmentID,
                        DepartmentOfIntrest= ctx.Departments.FirstOrDefault(d=>d.ID==_dogCatcherDepartment).Name
                    }).ToListAsync();
                return applicants;
            }
        }
        public async Task<List<ApplicantListItem>> GetCatCatcherApplicants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var applicants = await
                    ctx
                    .Applicants
                    .Where(a => a.DepartmentID == _catCatcherDepartment)
                    .Select(a => new ApplicantListItem()
                    {
                        ID = a.ID,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        DepartmentID=a.DepartmentID,
                        DepartmentOfIntrest = ctx.Departments.FirstOrDefault(d => d.ID == _catCatcherDepartment).Name
                    }).ToListAsync();
                return applicants;
            }
        }
        public async Task<List<ApplicantListItem>> GetPokemonCatcherApplicants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var applicants = await
                    ctx
                    .Applicants
                    .Where(a => a.DepartmentID == _pokemonCatcherDepartment)
                    .Select(a => new ApplicantListItem()
                    {
                        ID = a.ID,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        DepartmentID=a.DepartmentID,
                        DepartmentOfIntrest = ctx.Departments.FirstOrDefault(d => d.ID == _pokemonCatcherDepartment).Name
                    }).ToListAsync();
                return applicants;
            }
        }
        public async Task<List<ApplicantListItem>> GetHumanResourcesApplicants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var applicants = await
                    ctx
                    .Applicants
                    .Where(a => a.DepartmentID == _humanResourcesDepartment)
                    .Select(a => new ApplicantListItem()
                    {
                        ID = a.ID,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        DepartmentID=a.DepartmentID,
                        DepartmentOfIntrest = ctx.Departments.FirstOrDefault(d => d.ID == _humanResourcesDepartment).Name
                    }).ToListAsync();
                return applicants;
            }
        }

        //We can make a method that just deletes applicants after a while (specific period of time)/or if HR needs to delete them (bad data)
    }


}
