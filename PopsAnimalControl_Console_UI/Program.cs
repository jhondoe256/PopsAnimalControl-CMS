using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var programUI = new Program_UI();
            await programUI.Run();
        }
    }
}
