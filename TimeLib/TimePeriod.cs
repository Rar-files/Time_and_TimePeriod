namespace TimeLib
{
    public struct TimePeriod
    {
        public long seconds {get;}

        public TimePeriod(Time a, Time b)
        {
            Time bufor;
            if(a.CompareTo(b)!=1)
            {
                bufor = a;
                a = b;
                b = bufor;
            }
            seconds = a.Seconds - b.Seconds + 60*(a.Minutes - b.Minutes + 60*(a.Hours - b.Hours));
        }
    }
}