using PAC.Data.Reports.CatReports;
using PAC.Models.AnimalModels.CatModels;
using PAC.Models.ReportModels.CatReportModels;
using PAC.Services.CatServices;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.ReportServices.Cat_Report_Services
{
    public class CatCatcher_Report_Service
    {
        private readonly Guid _userId;
        private readonly CatService catService;
        public CatCatcher_Report_Service(Guid userId)
        {
            _userId = userId;
            catService = new CatService(userId);
        }
        public async Task<IEnumerable<CatReportListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var catReports =
                    await
                    ctx
                    .catReports
            //        .Where(c => c.OwnerID == _userId)
                    .Select(c => new CatReportListItem
                    {
                        ReportID=c.ReportID,
                        EmployeeID=c.EmployeeID,
                        EmployeeFirstName=c.FirstName,
                        EmployeeLastName=c.LastName
                    }).ToListAsync();
                return catReports;
            }
        }
        public async Task<CatReportDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var report = await ctx.catReports.SingleOrDefaultAsync(c => c.ReportID == id);
                if (report is null)
                {
                    return null;
                }
                
                var employee = await ctx.CatCatchers.SingleOrDefaultAsync(e => e.EmployeeID == report.EmployeeID);
                if (employee is null)
                {
                    return null;
                }

                return new CatReportDetail
                {
                    ReportID = report.ReportID,
                    EmployeeID = employee.EmployeeID,
                    EmployeeFirstName = employee.FirstName,
                    EmployeeLastName = employee.LastName,
                    PositionTitle = ctx.Positions.SingleOrDefault(p => p.PositionID == employee.PositionID).Name,
                    Name = report.Name,
                    CatBreedID=report.CatBreedID,
                    BreedName = ctx.Breeds.Find(report.CatBreedID).BreedName,
                    Age = report.Age,
                    DateOfBirth = report.DateOfBirth,
                    DateOfCapture = report.DateOfCapture,
                    HasCollarIdentification=report.HasCollarIdentification,
                    HasChipIdentification = report.HasChipIdentification,
                    TempermentType=report.TempermentType,
                    InjurySeverityType=report.InjurySeverityType,
                    EventDescription=report.EventDescription,
                    CaptureWorth=report.CaptureWorth,
                    CreationDate=report.CreationDate,
                    ModificationionDate=report.ModificationionDate
                };
            
            }
        }
        public async Task<bool> Post(CatReportCreate catReport)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var employee = await ctx.CatCatchers.SingleOrDefaultAsync(c => c.EmployeeID == catReport.EmployeeID);
                if (employee is null)
                {
                    return false;
                }
                var breed = await ctx.CatBreedTypes.SingleOrDefaultAsync(c=>c.ID == catReport.CatBreedID);
                if (breed is null)
                {
                    return false;
                }
                var entity = new CatReport()
                {
                    OwnerID=_userId,
                    EmployeeID=employee.EmployeeID,
                    FirstName=employee.FirstName,
                    LastName=employee.LastName,
                    CatBreedID=breed.ID,
                    CatBreed=breed,
                    DateOfBirth=catReport.DateOfBirth,
                    DateOfCapture=DateTime.Now,
                    HasChipIdentification=catReport.HasChipIdentification,
                    HasCollarIdentification=catReport.HasCollarIdentification,
                    TempermentType=catReport.TempermentType,
                    InjurySeverityType=catReport.InjurySeverityType,
                    Name=catReport.Name,
                    EventDescription=catReport.EventDescription,
                    CaptureWorth=catReport.CaptureWorth,
                    CreationDate=DateTime.Now
                };

                ctx.catReports.Add(entity);
                if (await ctx.SaveChangesAsync()>0)
                {
                    var catEntity = new CatCreate
                    {
                        CatBreedID= catReport.CatBreedID,
                        CaptureWorth=catReport.CaptureWorth,
                        DateOfBirth=catReport.DateOfBirth,
                        DateOfCapture=DateTime.Now,
                        HasChipIdentification=catReport.HasChipIdentification,
                        HasCollarIdentification=catReport.HasCollarIdentification,
                        InjurySeverityType=catReport.InjurySeverityType,
                        Name=catReport.Name,
                        TempermentType=catReport.TempermentType,
                        ReportID=entity.ReportID,
                    };

                    return await catService.Post(catEntity);
                }
                return false;
            }
        }
        public async Task<bool> Put(CatReportEdit catReport, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldReportData = await ctx.catReports.FindAsync(id);
                if (oldReportData is null)
                {
                    return false;
                }
                var oldCatData = await ctx.Cats.SingleOrDefaultAsync(c => c.Name == oldReportData.Name);
                if (oldCatData is null)
                {
                    return false;
                }

                var oldCatID = oldCatData.ID;

                oldReportData.CatBreedID = catReport.CatBreedID;
                oldReportData.CatBreed = ctx.CatBreedTypes.Find(catReport.CatBreedID);

                if (oldReportData.CatBreed is null)
                {
                    return false;
                }

                oldReportData.CaptureWorth = catReport.CaptureWorth;
                oldReportData.DateOfBirth = catReport.DateOfBirth;
                oldReportData.DateOfCapture = catReport.DateOfCapture;
                oldReportData.EmployeeID = catReport.EmployeeID;

                var employee = ctx.CatCatchers.SingleOrDefault(e => e.EmployeeID == catReport.EmployeeID);

                if (employee is null)
                {
                    return false;
                }

                oldReportData.FirstName = employee.FirstName;
                oldReportData.LastName = employee.LastName;
                oldReportData.Name = catReport.Name;
                oldReportData.TempermentType = catReport.TempermentType;
                oldReportData.InjurySeverityType = catReport.InjurySeverityType;
                oldReportData.HasChipIdentification = catReport.HasChipIdentification;
                oldReportData.HasCollarIdentification = catReport.HasCollarIdentification;
                oldReportData.ModificationionDate = DateTime.Now;

                oldCatData.Name = catReport.Name;
                oldCatData.HasChipIdentification = catReport.HasChipIdentification;
                oldCatData.HasCollarIdentification = catReport.HasCollarIdentification;
                oldCatData.TempermentType = catReport.TempermentType;
                oldCatData.DateOfCapture = catReport.DateOfCapture;
                oldCatData.DateOfBirth = catReport.DateOfBirth;
                oldCatData.CaptureWorth = catReport.CaptureWorth;
                oldCatData.CatBreedID = catReport.CatBreedID;
                oldCatData.InjurySeverityType = catReport.InjurySeverityType;

                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
