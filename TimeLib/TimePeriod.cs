using System;
namespace TimeLib
{
    public struct TimePeriod:IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        public long seconds {get;}

        public TimePeriod(long Seconds) => seconds = Seconds;
        public TimePeriod(byte Hours= 0, byte Minutes= 0, byte Seconds = 0)
        {
            seconds = ToSecond(Hours,Minutes,Seconds);
        }
        public TimePeriod(string timePeriod)
        {
            string[] _timePeriod = timePeriod.Split(':');
            try{ seconds = ToSecond(int.Parse(_timePeriod[0]),int.Parse(_timePeriod[1]),int.Parse(_timePeriod[2]));}
            catch(IndexOutOfRangeException) {throw new ArgumentException("Invalid format. Enter time: \"hh:mm:ss\"");}
        }
        public TimePeriod(Time a, Time b)
        {
            Time bufor;
            if(a.CompareTo(b)!=1)
            {
                bufor = a;
                a = b;
                b = bufor;
            }
            seconds = ToSecond(a.Hours - b.Hours, a.Minutes - b.Minutes, a.Seconds - b.Seconds);
        }

        private static long ToSecond(int h, int m, int s) => s + 60*(m + 60*h);

        public override string ToString() => $"{(seconds/3600)}:{(seconds/60)%60}:{seconds%60}";

        // override object.Equals
        public override bool Equals(object obj)
        {            
            if (GetType() != obj.GetType())
            {
                return false;
            }
            
            return Equals (obj);
        }
        public bool Equals(TimePeriod time)
        {
            if(time != null & this.GetHashCode() == time.GetHashCode())
                return true;
            return false;
        }        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int CompareTo(TimePeriod time)
        {
            if (time == null || GetType() != time.GetType()) throw new ArgumentException("The argument cannot be null and cannot be of type other than time");

            if(this.Equals(time)) return 0;
            else if(this.seconds<time.seconds) return -1;
            return 1;
        }

        public static bool operator ==(TimePeriod a, TimePeriod b) => a.Equals(b);
        public static bool operator !=(TimePeriod a, TimePeriod b) => !a.Equals(b);
        public static bool operator <(TimePeriod a, TimePeriod b)
        {
            if(a.CompareTo(b) == -1) return true;
            return false;
        }
        public static bool operator >(TimePeriod a, TimePeriod b)
        {
            if(a.CompareTo(b) == 1) return true;
            return false;
        }
        public static bool operator <=(TimePeriod a, TimePeriod b)
        {
            if(a.CompareTo(b) != 1) return false;
            return true;
        }
        public static bool operator >=(TimePeriod a, TimePeriod b)
        {
            if(a.CompareTo(b) != -1) return false;
            return true;
        }

        public static TimePeriod Plus(TimePeriod a, TimePeriod b) => new TimePeriod(a.seconds + b.seconds);
        public TimePeriod Plus(TimePeriod a) => Plus(this,a);
        public static TimePeriod Minus(TimePeriod a, TimePeriod b) => new TimePeriod(a.seconds-b.seconds);
        public TimePeriod Minus(TimePeriod a) => Minus(this,a);

        public static TimePeriod operator +(TimePeriod a, TimePeriod b) => Plus(a,b);
        public static TimePeriod operator -(TimePeriod a, TimePeriod b) => Minus(a,b);
        public static TimePeriod operator /(TimePeriod a, int b) => new TimePeriod(a.seconds/b);
        public static TimePeriod operator *(TimePeriod a, int b) => new TimePeriod(a.seconds*b);



    }
}