using System;
using TimeLib;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(1,5);
            Time t = new Time(21,6,0);
            TimePeriod tP = new TimePeriod(t,t1);
            TimePeriod tP2 = new TimePeriod("2:3:5");
            System.Console.WriteLine(tP.seconds);
            System.Console.WriteLine(tP);
            System.Console.WriteLine(t.CompareTo(t1));
            Console.WriteLine(t);
            System.Console.WriteLine(t-t1);
        }
    }
}
