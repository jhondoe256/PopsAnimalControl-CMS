using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.Utilities
{
    public class ApiMessenger
    {
        private static string baseURL = "https://localhost:44351/";

        public static string ApplicationUsers = $"{baseURL}api/ApplicationUser/";
        public static string AccountRegister = $"{baseURL}api/Account/Register/";
        public static string Token = $"{baseURL}token";

        public static string HumanResourcesHUB = $"{baseURL}api/HumanResourcesHUB/";
        public static string DogCatcherApplicants = $"{baseURL}api/HumanResourcesHUB/DogCatcherApplicants/";
        public static string CatCatcherApplicants = $"{baseURL}api/HumanResourcesHUB/CatCatcherApplicants/";
        public static string PokemonCatcherApplicants = $"{baseURL}api/HumanResourcesHUB/PokemonCatcherApplicants/";
        public static string HumanResourcesApplicants = $"{baseURL}api/HumanResourcesHUB/HumanResourcesApplicants/";

        public static string Applicant = $"{baseURL}api/Applicant/";
        public static string ApplicantInfo = $"{baseURL}api/Applicant/Info/";
        public static string ApplicantUpdate = $"{baseURL}api/Applicant/Update/";

        public static string Department = $"{baseURL}api/Departments/";
        public static string DepartmentCreate = $"{baseURL}api/Department/gInfo/";
        public static string DepartmentUpdate = $"{baseURL}api/Departments/Update/";


        public static string Position = $"{baseURL}api/Position/";
        public static string PositionUpdate = $"{baseURL}api/Position/Update/";
        public static string PositionDelete = $"{baseURL}api/Position/Delete/";

        public static string DogCatcher = $"{baseURL}api/DogCatcher/";

        public static string CatCatcher = $"{baseURL}api/CatCatcher/";

        public static string PokemonCatcher = $"{baseURL}api/PokemonCatcher/";

        public static string DogBreed = $"{baseURL}api/DogBreed/";
        public static string Dog = $"{baseURL}api/Dog/";
        public static string DogReport = $"{baseURL}api/DogReport/";

        public static string CatBreed = $"{baseURL}api/CatBreed/";
        public static string Cat = $"{baseURL}api/Cat/";
        public static string CatReport = $"{baseURL}api/CatCatcherReport/";

        public static string Pokemon = $"{baseURL}api/Pokemon/";
        public static string PokemonReport = $"{baseURL}api/PokemonReport/";
    }
}
