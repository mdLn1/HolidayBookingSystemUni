using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class GeneralUtils
{
    // Roles
    public const string ADMIN_ROLE = "Admin";
    public const string HEAD_ROLE = "Head";
    public const string DEPUTY_HEAD_ROLE = "Deputy Head";
    public const string MANAGER_ROLE = "Manager";
    public const string SENIOR_ROLE = "Senior";
    public const string APPRENTICE_ROLE = "Apprentice";
    public const string JUNIOR_ROLE = "Junior";

    // Departments
    public const string ENGINEERING_DEPARTMENT = "Engineering";
    public const string OFFICE_DEPARTMENT = "Office";
    public const string PLUMBING_DEPARTMENT = "Plumbing";
    public const string ROOFING_DEPARTMENT = "Roofing";
    public const string CARPENTRY_DEPARTMENT = "Carpentry";
    public const string BRICKLAYING_DEPARTMENT = "Bricklaying";
    public const string MANAGEMENT_DEPARTMENT = "Management";

    // Holiday Request Status
    public const string PENDING = "pending";
    public const string APPROVED = "accepted";
    public const string DECLINED = "declined";

    // Percentage of department on duty
    public const double REQUIRED_PERCENTAGE_AT_LEAST_MAX = 60;
    public const double REQUIRED_PERCENTAGE_AT_LEAST_MIN = 40;
    
    public const int MAX_POSSIBLE_HOLIDAY = 40;

    // Months
    public const int AUGUST = 8;

    // HTML Colors
    public const string WARNING_COLOR = "#8a6d3b";
    public const string DANGER_COLOR = "#a94442";
    public const string SUCCESS_COLOR = "#3c763d";

    public const int MINIMUM_NUMBER_MANAGERS_OR_SENIORS = 1;

    public static int CalculateHolidayAllowanceOnRegistration(DateTime startDate)
    {
        if (startDate.Year == DateTime.Now.Year)
        {
            return Convert.ToInt32(Math.Round((double)(365 - startDate.DayOfYear) / 12));
        }
        int years = DateTime.Now.Year - startDate.Year;
        return 30 + Convert.ToInt32(Math.Floor((double)years / 5));
    }

    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hashgen = new System.Security.Cryptography.HMACSHA512())
        {
            passwordHash = hashgen.ComputeHash(Encoding.UTF8.GetBytes(password));
            passwordSalt = hashgen.Key;
        }

    }
    public static int CalculateWorkingDays(DateTime from, DateTime to)
    {
        int workingDays = 0;
        while(from < to.AddDays(1))
        {
            if(!(from.DayOfWeek == DayOfWeek.Saturday || from.DayOfWeek == DayOfWeek.Sunday))
            {
                workingDays++;
            }
            from = from.AddDays(1);

        }
        return workingDays;
    }

    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                    return false;
            }

            return true;
        }
    }

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

    // https://stackoverflow.com/questions/2510383/how-can-i-calculate-what-date-good-friday-falls-on-given-a-year
    public static DateTime EasterSunday(int year)
    {
        int day = 0;
        int month = 0;

        int g = year % 19;
        int c = year / 100;
        int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
        int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

        day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
        month = 3;

        if (day > 31)
        {
            month++;
            day -= 31;
        }

        return new DateTime(year, month, day);
    }

}
