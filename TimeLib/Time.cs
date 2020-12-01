using System;

namespace TimeLib
{
    public struct Time
    {
        Byte Hours {get;}
        Byte Minutes {get;}
        Byte Seconds {get;}

        public Time(Byte hours = 0, Byte minutes = 0, Byte seconds = 0)
        {  
            if(hours>24 | minutes > 60 | seconds > 60)
                throw new ArgumentOutOfRangeException("Data parameters outside time range");
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public Time(string TimeString) //konstruktor dla wartości podanych w string "hh:mm:ss"
        {
            string[] TimeValueBufor = TimeString.Split(':');
            Byte hours = Byte.Parse(TimeValueBufor[0]);
            Byte minutes = Byte.Parse(TimeValueBufor[1]);
            Byte seconds = Byte.Parse(TimeValueBufor[2]);
            if(hours>24 | minutes > 60 | seconds > 60)
                throw new ArgumentOutOfRangeException("Data parameters outside time range");
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public override string ToString() => $"{Hours}:{Minutes}:{Seconds}";
    }
}
