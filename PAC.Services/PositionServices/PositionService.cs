using PAC.Data.Employees.Positions;
using PAC.Models.PositionModels;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.PositionServices
{
    public class PositionService
    {
        private readonly Guid _userID;
        public PositionService(Guid userID)
        {
            _userID = userID;
        }
        public PositionService()
        {

        }
        public async Task<bool> CreatePositionAsync(PositionCreate position)
        {
            var entity = new Position
            {
                OwnerID = _userID,
                Name = position.Name,
                DepartmentID = position.DepartmentID,
                AvailablePositionCount=position.AvailablePositionCount,
                CreationDate=DateTime.Now

            };

            using (var ctx = new ApplicationDbContext())
            {
                
                var department = await ctx.Departments.FindAsync(entity.DepartmentID);
                if (department!=null)
                {
                    department.Department_Positions.Add(entity);
                    ctx.Positions.Add(entity);
                    var changes= await ctx.SaveChangesAsync() > 0;
                    return changes;
                }
                return false;
            }
        }
        public async Task<IEnumerable<PositionListItem>> GetPositionsAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Positions
                 //   .Where(p => p.OwnerID == _userID)
                    .Select(p => new PositionListItem
                    {
                       // OwnerId=p.OwnerID,
                        PositionID = p.PositionID,
                        Name = p.Name
                    });
                return await query.ToListAsync();
            }
        }
        public async Task<PositionDetail> GetPositionDetailAsync(int positionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var position =
                    await
                    ctx
                    .Positions
                    .Include(p=>p.Department)
              //      .Where(p => p.OwnerID == _userID)
                    .SingleOrDefaultAsync(p => p.PositionID == positionID);
                if (position != null)
                {

                    return new PositionDetail
                    {
                        PositionID = position.PositionID,
                        Name = position.Name,
                        DepartmentName = ctx.Departments.Find(position.DepartmentID).Name,
                        AvailablePositionCount=position.AvailablePositionCount,
                        CreationDate = position.CreationDate,
                        ModificationDate = (position.ModificationDate == null) ? null : position.ModificationDate
                    };
                }
                return null;
            }
        }
        public async Task<bool> UpdatePosition(PositionEdit position, int positionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldPositionData = await ctx.Positions.FindAsync(positionID);

                if (oldPositionData is null)
                {
                    return false;
                }

                oldPositionData.Name = position.Name;
                oldPositionData.PositionID = position.PositionID;
             //   oldPositionData.DepartmentID = position.DepartmentID;
                oldPositionData.ModificationDate = DateTime.Now;
                oldPositionData.AvailablePositionCount = position.AvailablePositionCount;
                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> DeletePosition(int positionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var position = await ctx.Positions.FindAsync(positionID);
                if (position is null)
                {
                    return false;
                }
                ctx.Positions.Remove(position);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
