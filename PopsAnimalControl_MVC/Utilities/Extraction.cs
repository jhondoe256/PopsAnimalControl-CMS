using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Utilities
{
    public static class Extraction
    {
        public static string ExtractEmail(string email)
        {
            var extractedEmail = "";
            foreach (var item in email)
            {
                if (item != '@')
                {
                    extractedEmail += item;
                }
                else
                {
                    return extractedEmail;
                }
            }
            return null;
        }
    }
}