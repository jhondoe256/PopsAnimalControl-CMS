using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PopsAnimalControl_Console_UI.Repositories.RegisterModelRepo;
using PopsAnimalControl_Console_UI.Repositories.TokenModelRepo;
using PopsAnimalControl_Console_UI.Utilities;
using PopsAnimalControl_Console_UI.ViewModels.RegisterBindingModel;
using PopsAnimalControl_Console_UI.ViewModels.TokenViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI
{
    public class Program_UI
    {
        private RegisterModelRepository _regModelRepo;
        private TokenModelRepository _tokenRepo;
        public Program_UI()
        {
            _regModelRepo = new RegisterModelRepository(); 
            _tokenRepo = new TokenModelRepository();
        }
        public async Task Run()
        {
            await RunApplication();
        }

        private async Task RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Pops Animal Control Console Application\n" +
                                  "---Please make a Selection---\n" +
                                  "1.Register\n" +
                                  "2.LogIn\n" +
                                  "3.Exit Application\n");

                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                    await  RegisterUser();
                        break;
                    case "2":
                    await  LogInUser();
                        break;
                    case "3":
                        isRunning = ExitApplication();
                        break;
                    default:
                        Console.WriteLine("Invalid Selection, please try again.");
                        break;
                }
            Console.Clear();
            }
        }

        private bool ExitApplication()
        {
            Console.Clear();
            Console.WriteLine("Thank you for using PAC Services.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            return false;
        }

        private async Task LogInUser()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t-----Welcome to User Login-----\n\n\n\n");
            var logInModel = new TokenViewModel();

            //logInModel.grant_type = "password";
            Console.WriteLine("Please input your Email address.");
            var userName = Console.ReadLine();
            logInModel.username = userName;
            Console.WriteLine("Please input your password");
            var password = Console.ReadLine();
            logInModel.password = password;

            var success = await _tokenRepo.Post(logInModel, ApiMessenger.Token);
            if (success)
            {
                Console.Clear();
                Console.WriteLine("You should RETRIVE A TOKEN!!!!");
                Console.WriteLine("Press Any Key To Continue");
                Console.ReadKey();
            }


            //var users =await _regModelRepo.GetUsers();
            // var success = users.Any(u => u.Email == userName);
            // if (success)
            // {
            //     var user = users.SingleOrDefault(u => u.Email == userName);
            //     Console.WriteLine($"{ user.Email} {user.Id}");
            //     Console.ReadKey();
            // }
        }

        private async Task RegisterUser()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t-----Welcome to User Registration-----\n\n\n\n");
            var userModel = new RegisterBindingModel();
            Console.WriteLine("Please input an email address.");
            var userEmail = Console.ReadLine();
            Console.WriteLine("Please input a Password");
            var userPassword = Console.ReadLine();
            Console.WriteLine("Please Confirm the Password");
            var userPasswordConfirm = Console.ReadLine();

            userModel.Email = userEmail;
            userModel.Password = userPassword;
            userModel.ConfirmPassword = userPasswordConfirm;

            var success= await _regModelRepo.Post(userModel, ApiMessenger.AccountRegister);

            if (success)
            {
                Console.Clear();
                Console.WriteLine("Thanks, you have been SUCCESSFULLY ADDED!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("SORRY, something went HORRIBLY WRONG!!!!");
            }
        }

    }
}
