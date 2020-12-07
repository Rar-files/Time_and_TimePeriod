using System.Reflection.Emit;
using System;

namespace TimeLib
{
    public struct Time:IEquatable<Time>, IComparable<Time>
    {
        public byte Hours {get;}
        public byte Minutes {get;}
        public byte Seconds {get;}


        public Time(long seconds)
        {
            byte _hours = Convert.ToByte(seconds/3600);
            byte _minutes = Convert.ToByte((seconds/60)%60);
            byte _seconds = Convert.ToByte(seconds%60);

            constructorExceptions(_hours,_minutes,_seconds);
            Hours = _hours;
            Minutes = _minutes;
            Seconds = _seconds;
        }
        public Time(byte hours = 0, byte minutes = 0, byte seconds = 0)
        {  
            constructorExceptions(hours,minutes,seconds);
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public Time(string TimeString) //konstruktor dla wartości podanych w string "hh:mm:ss"
        {
            string[] TimeValueBufor = TimeString.Split(':');
            byte hours = byte.Parse(TimeValueBufor[0]);
            byte minutes = byte.Parse(TimeValueBufor[1]);
            byte seconds = byte.Parse(TimeValueBufor[2]);
            constructorExceptions(hours,minutes,seconds);
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        private static void constructorExceptions(byte hours, byte minutes, byte seconds)
        {
            if(hours>24 | minutes > 60 | seconds > 60)
                throw new ArgumentOutOfRangeException("Data parameters outside time range");       
        }


        public override string ToString() => $"{Hours.ToString("D2")}:{Minutes.ToString("D2")}:{Seconds.ToString("D2")}";

        public override bool Equals(object obj)
        {
            if(GetType() == obj.GetType())
                return false;
            return this.Equals(obj);
        }
        public bool Equals(Time time)
        {
            if (time != null)
            {
                if(this.GetHashCode()==time.GetHashCode())
                    return true;
            }
            return false;            
        }       
        public override int GetHashCode() => int.Parse($"{this.Hours}{this.Minutes}{this.Seconds}");
        public int CompareTo(Time time)
        {
            if (time == null || GetType() != time.GetType()) throw new ArgumentException("The argument cannot be null and cannot be of type other than time");

            if(this.Equals(time)) return 0;
            else if(this.GetHashCode()<time.GetHashCode()) return -1;
            return 1;
        }
 
        public static bool operator ==(Time a, Time b) => a.Equals(b);
        public static bool operator !=(Time a, Time b) => !a.Equals(b);
        public static bool operator <(Time a, Time b)
        {
            if(a.CompareTo(b) == -1) return true;
            return false;
        }
        public static bool operator >(Time a, Time b)
        {
            if(a.CompareTo(b) == 1) return true;
            return false;
        }
        public static bool operator <=(Time a, Time b)
        {
            if(a.CompareTo(b) != 1) return false;
            return true;
        }
        public static bool operator >=(Time a, Time b)
        {
            if(a.CompareTo(b) != -1) return false;
            return true;
        }

        public static Time Plus(Time a, Time b)
        {
            int sec = a.Seconds+b.Seconds;
            int min = a.Minutes+b.Minutes+(sec/60);
            int h = a.Hours+b.Hours+(min/60);
            return new Time(Convert.ToByte(h%24),Convert.ToByte(min%60),Convert.ToByte(sec%60));
        }
        public static Time Minus(Time a, Time b)
        {
            int h = a.Hours-b.Hours;
            int min = a.Minutes-b.Minutes;
            if(min<0) {h--; min = 60+min;}
            int sec = a.Seconds-b.Seconds;
            if(sec<0)
                if(min==0) {h--; min = 59; sec = 60+sec;}
                else {min--; sec = 60+sec;}
            return new Time(Convert.ToByte(h%24),Convert.ToByte(min%60),Convert.ToByte(sec%60));
        }
        public static Time Plus(Time a, TimePeriod b) => Plus(a, new Time(b.seconds));
        public Time Plus(TimePeriod a) => Plus(this, a);

        public static Time operator +(Time a, Time b) => Plus(a,b);
        public static Time operator -(Time a, Time b) => Minus(a,b);

    }
}