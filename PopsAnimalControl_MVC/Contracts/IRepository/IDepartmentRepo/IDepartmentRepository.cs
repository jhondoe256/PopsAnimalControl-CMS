using PopsAnimalControl_MVC.Models.DataModels.DepartmentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Contracts.IRepository.IDepartmentRepo
{
    public interface IDepartmentRepository:IBaseRepository<Department>
    {
    }
}