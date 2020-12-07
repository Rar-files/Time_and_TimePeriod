using System.Data;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLib;

namespace TimeLibTest
{
    [TestClass]
    public class TimeUnitTest
    {
        [DataTestMethod]
        [DataRow(0,0,0)]
        [DataRow(1,0,0)]
        [DataRow(1,51,23)]
        [DataRow(23,59,59)]
        public void TimeConstructor_TimeHMS_CorectConstructObject(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            var obj = new Time(h,m,s);
            bool result = false;
            if(obj.Hours == h & obj.Minutes == m & obj.Seconds == s)
                result = true;
            Assert.IsTrue(result, "The data entered into the constructor has not been assigned to the Properties");
        }

        [DataTestMethod]
        [DataRow(25,0,0)]
        [DataRow(0,61,0)]
        [DataRow(0,0,61)]
        public void TimeConstructor_TimeHMS_throwException(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            bool result = false;
            try{var obj = new Time(h,m,s);}
            catch(ArgumentOutOfRangeException) {result = true;}
            Assert.IsTrue(result, "The object does not throw an exception in case of invalid data");
        }

        [DataTestMethod]
        [DataRow(0,0,0)]
        [DataRow(1,0,0)]
        [DataRow(1,51,23)]
        [DataRow(23,59,59)]
        public void TimeConstructor_TimeLongSecond_CorrectConstructObject(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            long seconds = s + 60*(m + 60*h);
            var obj = new Time(seconds);
            bool result = false;
            if(obj.Hours == h & obj.Minutes == m & obj.Seconds == s)
                result = true;
            Assert.IsTrue(result, "The data entered into the constructor has not been assigned to the Properties");
        }

        [DataTestMethod]
        [DataRow(25,0,0)]
        public void TimeConstructor_TimeLongSecond_throwException(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            long seconds = s + 60*(m + 60*h);
            bool result = false;
            try{var obj = new Time(seconds);}
            catch(ArgumentOutOfRangeException) {result = true;}
            Assert.IsTrue(result, "The object does not throw an exception in case of invalid data");
        }

        [DataTestMethod]
        [DataRow(0,0,0)]
        [DataRow(1,0,0)]
        [DataRow(1,51,23)]
        [DataRow(23,59,59)]
        public void TimeConstructor_TimeString_CorrectConstructObject(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            string timeString = $"{h}:{m}:{s}";
            var obj = new Time(timeString);
            bool result = false;
            if(obj.Hours == h & obj.Minutes == m & obj.Seconds == s)
                result = true;
            Assert.IsTrue(result, "The data entered into the constructor has not been assigned to the Properties");
        }

        [DataTestMethod]
        [DataRow(25,0,0)]
        [DataRow(0,61,0)]
        [DataRow(0,0,61)]
        public void TimeConstructor_TimeString_throwException(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            string timeString = $"{h}:{m}:{s}";
            bool result = false;
            try{var obj = new Time(timeString);}
            catch(ArgumentOutOfRangeException) {result = true;}
            Assert.IsTrue(result, "The object does not throw an exception in case of invalid data");
        }

        [DataTestMethod]
        [DataRow(0,0,0)]
        [DataRow(1,0,0)]
        [DataRow(1,51,23)]
        [DataRow(23,59,59)]
        public void TimeToString_CorrectOutString(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            var obj1 = new Time(h,m,s);
            var obj2 = new Time(obj1.ToString());
            bool result = false;
            if(obj2.Hours == h & obj2.Minutes == m & obj2.Seconds == s)
                result = true;
            Assert.IsTrue(result, "ToString return valid time string");
        }

        [DataTestMethod]
        [DataRow(0,0,0)]
        [DataRow(1,0,0)]
        [DataRow(1,51,23)]
        [DataRow(23,59,59)]
        public void TimeEquals_TheSameObjects(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            var obj1 = new Time(h,m,s);
            var obj2 = new Time(h,m,s);
            bool result = false;
            if(obj1==obj2)
                result = true;
            Assert.IsTrue(result, "The statement equal returns false for the same objects");
        }

        [DataTestMethod]
        [DataRow(0,1,0)]
        [DataRow(1,0,33)]
        [DataRow(1,51,23)]
        [DataRow(23,58,59)]
        public void TimeEquals_NotTheSameObjects(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            var obj1 = new Time(h,m,s);
            var obj2 = new Time(h,s,m);
            bool result = false;
            if(obj1!=obj2)
                result = true;
            Assert.IsTrue(result, "The statement equal returns true for not the same objects");
        }

        [DataTestMethod]
        [DataRow(0,1,0)]
        [DataRow(1,0,33)]
        [DataRow(1,51,23)]
        [DataRow(23,58,59)]
        public void TimeCompare_TheSameObjects(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            var obj1 = new Time(h,m,s);
            var obj2 = new Time(h,m,s);
            bool result = false;
            if(obj1.CompareTo(obj2) == 0)
                result = true;
            Assert.IsTrue(result, "The statement CompareTo returns other value then 0, for the same objects");
        }

        [DataTestMethod]
        [DataRow(23,58,59)]
        public void TimeCompare_IsLessThan(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            var obj1 = new Time(h,m,Convert.ToByte(s-1));
            var obj2 = new Time(h,m,s);
            bool result = false;
            if(obj1<obj2)
                result = true;
            Assert.IsTrue(result, "The operator < returns false for less<greater objects");
        }

        [DataTestMethod]
        [DataRow(23,58,59)]
        public void TimeCompare_IsGreaterThan(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            var obj1 = new Time(h,m,s);
            var obj2 = new Time(h,m,Convert.ToByte(s-1));
            bool result = false;
            if(obj1>obj2)
                result = true;
            Assert.IsTrue(result, "The operator > returns false for greater>less objects");
        }

        [DataTestMethod]
        [DataRow(0,0,0)]
        [DataRow(1,0,0)]
        [DataRow(6,20,23)]
        [DataRow(11,30,30)]
        public void TimePlusOrMinus(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            var obj1 = new Time(h,m,s);
            var obj2 = obj1+obj1;
            bool result = false;
            if(obj2-obj1==new Time(h,m,s))
                result = true;
            Assert.IsTrue(result, "The statement + or - returns valid object");
        }
        
        [DataTestMethod]
        [DataRow(12,30,30)]
        public void TimePlusOrMinus_ThrowExceptionWhenPropertyOverflow(int _h,int _m, int _s)
        {
            byte h = Convert.ToByte(_h);
            byte m = Convert.ToByte(_m);
            byte s = Convert.ToByte(_s);
            var obj1 = new Time(h,m,s);
            bool result = false;
            try
            {
                var obj2 = obj1+obj1;
                obj1 = obj2-obj1;
            }
            catch(ArgumentOutOfRangeException) {result = true;}
            catch(OverflowException) {result = true;}
            Assert.IsTrue(result, "The object does not throw an exception when time property overflow");
        }

    }
}
