using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    
    

    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class DateTime
    {
        private int _sec, _min, _hour, _day, _month, _year;

        public DateTime()
        {

        }

        public DateTime(int year, int month, int day)
        {
            _year = year; 
            _month = month; 
            _day = day; 
        }

        public DateTime(int year, int month, int day, int hour, int min, int sec)
        {
            _year = year;
            _month = month;
            _day = day;
            _hour = hour;
            _min = min;
            _sec = sec;
        } 

        public int GetYear()
        {
            return _year;
        }

        public int GetMonth()
        {
            return _month;
        }

        public int GetDay()
        {
            return _day;
        }

        public int GetHour()
        {
            return _hour;
        }

        public int GetMin()
        {
            return _min;
        }

        public int GetSec()
        {
            return _sec;
        }

        public bool IsValid()
        { // 1, 3, 5, 7, 8, 10, 12 
            if (_month > 12 || _day > 31 || _hour > 23 || _min > 59 || _sec > 59 ||
                _month < 1 || _day < 1 || _hour < 0 || _min < 0 || _sec < 0)
                return false;
            if (_month == 2 && _day > 28)
                {
                    if (IsLeap() && _day > 29)
                        return false;
                    
                    if (!IsLeap() && _day > 28)
                    return false;
            }

            if (_month == 2 || _month == 4 || _month == 6 || _month == 9 || _month == 11 && _day == 31)
                return false;
            return true;
        }
        
        public bool IsLeap()
        {
            return IsLeap(_year);
        }

        public static bool IsLeap(int year)
        {
            return year % 4 == 0 && year % 100 != 0 || year % 100 == 0 && year % 400 == 0;
        }

        public string ToString()
        {
            string 
                year = Convert.ToString(_year), 
                month = Convert.ToString(_month), 
                day = Convert.ToString(_day);
            if (_month < 10)
                month = 0 + month;
            if (_day < 10)
                day = 0 + day;

                return _year + "/" + _month + "/" + _day;
        }

        public DateTime Clone()
        {
             return new DateTime(_year, _month, _day, _hour, _min, _sec);
        }

        public bool Equals(DateTime dt)
        {
            return _year == dt.GetYear() && _month == dt.GetMonth() && _day == dt.GetDay();
        }

        public void IncrementDay()
        {
            if (IsValid())
            {
                _day++;
                if (!IsValid())
                {
                    _day = 1;
                    _month += 1;
                    if (!IsValid())
                    {
                        _month = 1;
                        _year++;
                    }
                }
            }
        }

        public void IncrementSecond()
        {
            if (IsValid())
            {
                _sec++;
                if (!IsValid())
                {
                    _sec = 0;
                    _min++;
                    if (!IsValid())
                    {
                        _min = 0;
                        _hour++;
                        if (!IsValid())
                            IncrementDay();
                    }
                }
            }
        }


        private ulong CalcDayNumFromDate(int y, int m, int d)
        {
            if (IsValid())
            {
                m = (m + 9) % 12;
                y -= m / 10;
                ulong dn = (ulong)(365 * y + y / 4 - y / 100 + y / 400 + (m * 306 + 5) / 10 + (d - 1));
                return dn;
            }
            return ulong.MinValue;
        }

        public DayOfWeek? GetDayOfWeek()
        {
            ulong dayNum = CalcDayNumFromDate(_year, _month, _day);
            if (dayNum == ulong.MinValue)
                return null;
            return (DayOfWeek)(dayNum % 7);
        }
    }
}
