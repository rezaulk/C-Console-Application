using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Bill
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Enter a date: ");
            DateTime Starttime;
            bool Startdatecheck = false;
            bool Enddatecheck = false;

            if (DateTime.TryParse(Console.ReadLine(), out Starttime))
            {
                Startdatecheck = true;
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
            }

            Console.WriteLine("Enter a date: ");
            DateTime Endtime;
            if (DateTime.TryParse(Console.ReadLine(), out Endtime))
            {
                Enddatecheck = true;
            }
            else
            {
         
                Console.WriteLine("You have entered an incorrect value.");
            }

            if(Startdatecheck == true && Enddatecheck == true)
            {
                var diff = System.Math.Abs((Endtime - Starttime).TotalSeconds);
                var TotalAmount = 0;

                Console.WriteLine("Breakdown: ");

                while (diff > -1)
                {
                    DateTime BeforeChangedTime = Starttime;
                    Starttime = Starttime.AddSeconds(20);
                    int poisa = GetPulse(Starttime);
                    Console.WriteLine(BeforeChangedTime + " + 20 second (" + Starttime + ") = " + poisa + " paisa");
                    
                    TotalAmount += poisa;
                    diff -= 20;
                }

                double money = (double)TotalAmount / 100;
                Console.WriteLine(money + " Taka");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
                Console.ReadLine();

            }
        }

        static public int GetPulse(DateTime date)
        {

            int ActualTime = date.Hour;
            if (ActualTime >= 9 && ActualTime <= 23)
            {
                return 30;
            }
            else
            {
                return 20;
            }
        }
        
    }
}
