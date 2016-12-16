using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smswa.accelerator.data.upgrade
{
    public class Program
    {
        static int Main(string[] args)
        {
            Updater updater = new Updater();
            var result = updater.UpdateToCurrent();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }
            return 0;
        }
    }
}
