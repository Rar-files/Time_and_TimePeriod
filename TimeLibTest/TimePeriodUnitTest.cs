using System.Data;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLib;

namespace TimeLibTest
{
    [TestClass]
    public class TimePeriodUnitTest
    {
        private static long ToSecond(int h, int m, int s) => s + 60*(m + 60*h);

        [DataTestMethod]
        [DataRow(0,0,0)]
        [DataRow(1,0,0)]
        [DataRow(1,51,23)]
        [DataRow(23,59,59)]
        public void TimePeriodConstructor_TimeHMS_CorectConstructObject(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            var obj = new TimePeriod(h,m,s);
            bool result = false;
            if(obj.seconds == ToSecond(h,m,s))
                result = true;
            Assert.IsTrue(result, "The data entered into the constructor has not been assigned to the Properties");
        }


        [DataTestMethod]
        [DataRow(0,0,0)]
        [DataRow(1,0,0)]
        [DataRow(1,51,23)]
        [DataRow(23,59,59)]
        public void TimePeriodConstructor_TimeString_CorrectConstructObject(int h,int m, int s)
        {
            string timeString = $"{h}:{m}:{s}";
            var obj = new TimePeriod(timeString);
            bool result = false;
            if(obj.seconds == ToSecond(h,m,s))
                result = true;
            Assert.IsTrue(result, "The data entered into the constructor has not been assigned to the Properties");
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(28)]
        [DataRow(90000)]
        [DataRow(90059)]
        public void TimePeriodToString_CorrectOutString(int Seconds)
        {
            var obj1 = new TimePeriod(Seconds);
            var obj2 = new TimePeriod(obj1.ToString());
            bool result = false;
            if(obj2.seconds == Seconds)
                result = true;
            Assert.IsTrue(result, "ToString return valid time string");
        }
        
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(28)]
        [DataRow(900)]
        public void TimePeriodEquals_TheSameObjects(int Seconds)
        {
            var obj1 = new Time(Seconds);
            var obj2 = new Time(Seconds);
            bool result = false;
            if(obj1==obj2)
                result = true;
            Assert.IsTrue(result, "The statement equal returns false for the same objects");
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(28)]
        [DataRow(900)]
        public void TimePeriodEquals_NotTheSameObjects(int Seconds)
        {
            var obj1 = new Time(Seconds);
            var obj2 = new Time(Seconds+1);
            bool result = false;
            if(obj1!=obj2)
                result = true;
            Assert.IsTrue(result, "The statement equal returns true for not the same objects");
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(28)]
        [DataRow(900)]
        public void TimePeriodCompare_TheSameObjects(int Seconds)
        {
            var obj1 = new Time(Seconds);
            var obj2 = new Time(Seconds);
            bool result = false;
            if(obj1.CompareTo(obj2) == 0)
                result = true;
            Assert.IsTrue(result, "The statement CompareTo returns other value then 0, for the same objects");
        }

        [DataTestMethod]
        [DataRow(900)]
        public void TimePeriodCompare_IsLessThan(int Seconds)
        {
            var obj1 = new Time(Seconds);
            var obj2 = new Time(Seconds+1);
            bool result = false;
            if(obj1<obj2)
                result = true;
            Assert.IsTrue(result, "The operator < returns false for less<greater objects");
        }

        [DataTestMethod]
        [DataRow(900)]
        public void TimePeriodCompare_IsGreaterThan(int Seconds)
        {
            var obj1 = new Time(Seconds+1);
            var obj2 = new Time(Seconds);
            bool result = false;
            if(obj1>obj2)
                result = true;
            Assert.IsTrue(result, "The operator > returns false for greater>less objects");
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(28)]
        [DataRow(900)]
        public void TimePeriodPlusOrMinus(int Seconds)
        {
            var obj1 = new Time(Seconds);
            var obj2 = obj1+obj1;
            bool result = false;
            if(obj2-obj1==new Time(Seconds))
                result = true;
            Assert.IsTrue(result, "The statement + or - returns valid object");
        }
        
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(28)]
        [DataRow(900)]
        public void TimePeriodMultiplyOrdivide(int Seconds)
        {
            var obj1 = new TimePeriod(Seconds);
            var obj2 = obj1*Seconds;
            bool result = false;
            if(obj2/Seconds==new TimePeriod(Seconds))
                result = true;
            Assert.IsTrue(result, "The statement * or / returns valid object");
        }

    }
}
