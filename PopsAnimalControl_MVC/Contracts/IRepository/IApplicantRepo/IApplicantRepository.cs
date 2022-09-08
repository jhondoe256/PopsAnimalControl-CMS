using PopsAnimalControl_MVC.Models.DataModels.ApplicantData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Contracts.IRepository.IApplicantRepo
{
    public interface IApplicantRepository:IBaseRepository<Applicant>
    {
    }
}