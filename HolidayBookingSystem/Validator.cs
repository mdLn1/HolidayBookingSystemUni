using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HolidayBookingSystem
{
    public static class Validator
    {
        public static bool checkPasswordComplexity(string password)
        {
            string patternPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,32}$";
            if (!string.IsNullOrEmpty(password))
            {
                if (!Regex.IsMatch(password, patternPassword))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
