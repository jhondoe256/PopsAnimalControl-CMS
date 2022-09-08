using PAC.Data.Animals.Dogs;
using PAC.Data.Reports.DogReports;
using PAC.Models.DogModels;
using PAC.Models.ReportModels.DogReportModels;
using PAC.Services.DogServices;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.ReportServices.Dog_Report_Services
{
    public class DogCatcher_Report_Service
    {
        private readonly Guid _userId;
        private readonly DogService dogService;
        public DogCatcher_Report_Service(Guid userId)
        {
            _userId = userId;
            dogService = new DogService(userId);

        }
        public async Task<IEnumerable<DogReportListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .DogReports
                  //  .Where(d => d.OwnerID == _userId)
                    .Select(d => new DogReportListItem
                    {
                        ReportID = d.ReportID,
                        EmployeeID = d.EmployeeID,
                        EmployeeFirstName = d.FirstName,
                        EmployeeLastName = d.LastName,
                        CreationDate = d.CreationDate
                    }).ToListAsync();

                return query;
            }
        }
        public async Task<DogReportDetails> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var report = await ctx.DogReports.Include(d=>d.Breed).SingleOrDefaultAsync(d => d.ReportID == id);
                if (report is null)
                {
                    return null;
                }
                var emplooyee = await ctx.DogCatchers.SingleOrDefaultAsync(e => e.EmployeeID == report.EmployeeID);
                if (emplooyee is null)
                {
                    return null;
                }
                return  new DogReportDetails
                {
                    ReportID = report.ReportID,
                    EmployeeID = report.EmployeeID,
                    EmployeeFirstName = report.FirstName, 
                    EmployeeLastName = report.LastName,
                    PositionTitle =ctx.Positions.SingleOrDefault(p=>p.PositionID==emplooyee.PositionID).Name,
                    Name = report.Name,
                    BreedID=report.BreedID,
                    BreedName=ctx.Breeds.Find(report.BreedID).BreedName,
                    Age = report.Age,
                    DateOfBirth = report.DateOfBirth,
                    DateOfCapture = report.DateOfCapture,
                    HasCollarIdentification = report.HasCollarIdentification,
                    HasChipIdentification = report.HasChipIdentification,
                    TempermentType = report.TempermentType.ToString(),
                    InjurySeverityType = report.InjurySeverityType.ToString(),
                    EventDescription = report.EventDescription,
                    CaptureWorth = report.CaptureWorth,
                    CreationDate=report.CreationDate,
                    ModificationionDate=report.ModificationionDate,
                    
                };
            }
        }
        public async Task<bool> Post(DogReportCreate dogReport)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var employee =await ctx.DogCatchers.SingleOrDefaultAsync(e => e.EmployeeID == dogReport.EmployeeID);
                if (employee is null)
                {
                    return false;
                }
                var breed = await  ctx.Breeds.SingleOrDefaultAsync(b => b.BreedID== dogReport.BreedID);
                if (breed is null)
                {
                    return false;
                }
                var entity = new DogReport
                {
                    OwnerID=_userId,
                    EmployeeID = dogReport.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName=employee.LastName,
                    BreedID=dogReport.BreedID,
                    Breed=breed,
                    DateOfBirth=dogReport.DateOfBirth,
                    DateOfCapture=DateTime.Now,
                    HasCollarIdentification=dogReport.HasCollarIdentification,
                    HasChipIdentification=dogReport.HasChipIdentification,
                    TempermentType=dogReport.TempermentType,
                    InjurySeverityType=dogReport.InjurySeverityType,
                    Name=dogReport.Name,
                    EventDescription=dogReport.EventDescription,
                    CaptureWorth=dogReport.CaptureWorth,
                    CreationDate=DateTime.Now,
                    
                };

                ctx.DogReports.Add(entity);
                if (await ctx.SaveChangesAsync()==1)
                {
                    var dogEntity = new DogCreate
                    {
                        BreedID = dogReport.BreedID,
                        Breed = breed,
                        CaptureWorth = dogReport.CaptureWorth,
                        DateOfBirth = dogReport.DateOfBirth,
                        DateOfCapture = DateTime.Now,
                        HasChipIdentification = dogReport.HasChipIdentification,
                        HasCollarIdentification = dogReport.HasCollarIdentification,
                        InjurtServerityType = dogReport.InjurySeverityType,
                        Name = dogReport.Name,
                        TempermentType = dogReport.TempermentType,
                        ReportID = entity.ReportID,
                        DogReport=entity
                    };

                   return await dogService.Post(dogEntity);
                   
                }
                    return false;
            }
        }
        public async Task<bool> Put(DogReportEdit dogReport, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldReportData = await ctx.DogReports.FindAsync(id);
              
                if (oldReportData is null)
                {
                    return false;
                }
                var oldDogData = ctx.Dogs.SingleOrDefault(d => d.Name == oldReportData.Name);

                if (oldDogData is null)
                {
                    return false;
                }

                var oldDogID =  oldDogData.ID;    
               
                oldReportData.BreedID = dogReport.BreedID;
                oldReportData.Breed = ctx.Breeds.Find(dogReport.BreedID);

                if (oldReportData.Breed is null)
                {
                    return false;
                }

                oldReportData.CaptureWorth = dogReport.CaptureWorth;
                oldReportData.DateOfBirth = dogReport.DateOfBirth;
                oldReportData.DateOfCapture = oldDogData.DateOfCapture;
                oldReportData.EmployeeID = dogReport.EmployeeID;
                var employee = ctx.Employees.SingleOrDefault(e => e.EmployeeID == dogReport.EmployeeID);

                if (employee is null)
                {
                    return false;
                }
                oldReportData.FirstName = employee.FirstName;
                oldReportData.LastName = employee.LastName;
                oldReportData.Name = dogReport.Name;
                oldReportData.TempermentType = dogReport.TempermentType;
                oldReportData.InjurySeverityType = dogReport.InjurySeverityType;
                oldReportData.HasChipIdentification = dogReport.HasChipIdentification;
                oldReportData.HasCollarIdentification = dogReport.HasCollarIdentification;
                oldReportData.ModificationionDate = DateTime.Now;

                oldDogData.Name = dogReport.Name;
                oldDogData.HasChipIdentification = dogReport.HasChipIdentification;
                oldDogData.HasCollarIdentification = dogReport.HasCollarIdentification;
                oldDogData.TempermentType = dogReport.TempermentType;
                oldDogData.DateOfCapture = oldDogData.DateOfCapture;
                oldDogData.DateOfBirth = dogReport.DateOfBirth;
                oldDogData.CaptureWorth = dogReport.CaptureWorth;
                oldDogData.BreedID = dogReport.BreedID;
                oldDogData.Breed = ctx.Breeds.Find(dogReport.BreedID);
                oldDogData.InjurySeverityType = dogReport.InjurySeverityType;


                return await ctx.SaveChangesAsync() > 0;
            }
        }
        //public async Task<bool> Delete(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var report =
        //            await
        //            ctx
        //            .DogReports
        //            .Where(d => d.OwnerID == _userId)
        //            .SingleOrDefaultAsync(d => d.ReportID == id);
        //        if (report is null)
        //        {
        //            return false;
        //        }
        //        ctx.DogReports.Remove(report);
        //        return await ctx.SaveChangesAsync() > 0;
        //    }
        //}
    }
}
