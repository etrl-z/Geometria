using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    static class Utility
    {
        public static string LeggiStringa(string msg)
        {
            Console.WriteLine(msg);
            string str = Console.ReadLine();
            return str;
        }

        public static int LeggiIntero(string msg)
        {
            Console.WriteLine(msg);

            while (true)
            {
                try
                {
                    int intNum = Convert.ToInt32(Console.ReadLine());
                    if (intNum > 0)
                    {
                        return intNum;
                    }
                    else
                    {
                        Console.WriteLine("Valore non accettabile!");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Scelta non valida!");
                }
            }; 
        }
    }
}
