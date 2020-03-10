using HBSDatabase;
using SolutionUtils;
using System;
using System.Collections.Generic;
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

    // Broken constraints
    public const string CONSTRAINT_DEPUTY_OR_HEAD = "Either the head or the deputy head of the department must be on duty";
    public const string CONSTRAINT_AT_LEAST_60_PERCENT = "At least 60% of a department must be on duty";
    public const string CONSTRAINT_AT_LEAST_40_PERCENT = "At least 40% of a department must be on duty";
    public const string CONSTRAINT_MINIMUM_SENIOR_OR_MANAGERS = "At least one manager and one senior staff member must be on duty";
    public const string CONSTRAINT_HOLIDAY_ENTITLEMENT_EXCEEDED = "No employee can exceed the number of days of holiday entitlement";

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
    public const string CHANGED = "changed";
    public const string APPROVED = "accepted";
    public const string DECLINED = "declined";

    // Percentage of department on duty
    public const double REQUIRED_PERCENTAGE_AT_LEAST_MAX = 60;
    public const double REQUIRED_PERCENTAGE_AT_LEAST_MIN = 40;

    // max number of holiday request, before submitting a request
    public const int MAX_POSSIBLE_HOLIDAY = 40;

    // Months
    public const int AUGUST = 8;

    // Suggesstions
    public const int SUGGESTIONS_MAX_DAYS_BOUNDARY = 7;

    // HTML Colors
    public const string WARNING_COLOR = "#8a6d3b";
    public const string DANGER_COLOR = "#a94442";
    public const string SUCCESS_COLOR = "#3c763d";

    // refers to one of the constraints
    public const int MINIMUM_NUMBER_MANAGERS_OR_SENIORS = 1;

    // for Suggestions
    public static int MaxSuggestionsCount { get; set; } = 10;

    // dates when no constraints apply
    public static List<DateRange> noConstraintsApply = new List<DateRange>()
    {
        new DateRange(new DateTime(2020, 12, 23), new DateTime(2021,1,3))
    };

    // dates when a lesser percentage of meployees is required
    public static List<DateRange> lessEmployeePercentageRequired = new List<DateRange>()
    {
        new DateRange(new DateTime(2020, 08, 1), new DateTime(2020, 08, 31))
    };

    // if date falls on weekend, set it as Monday
    public static DateTime simplifyStartDate(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Saturday)
        {
            return date.AddDays(2);
        }
        else if (date.DayOfWeek == DayOfWeek.Sunday)
        {
            return date.AddDays(1);
        }
        return date;
    }

    // if date falls on weekend, set it as Friday
    public static DateTime simplifyEndDate(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Saturday)
        {
            return date.AddDays(-1);
        }
        else if (date.DayOfWeek == DayOfWeek.Sunday)
        {
            return date.AddDays(-2);
        }
        return date;
    }

    // calculate Peak Times for a certain number of years ahead
    public static List<DateRange> getPeakTimes(int yearsInAdvance = 1)
    {
        List<DateRange> dateRanges = new List<DateRange>();
        int currentYear = DateTime.Now.Year;
        for (int i = 0; i < yearsInAdvance; i++)
        {
            // 15th of July till 31st of August
            dateRanges.Add(new DateRange(new DateTime(currentYear + i, 7, 15)
                    , new DateTime(currentYear + i, 8, 31)));
            // 15th of December to 22nd of December
            dateRanges.Add(new DateRange(new DateTime(currentYear + i, 12, 15)
                    , new DateTime(currentYear + i, 12, 22)));
            // week before and after Easter
            DateTime easter = EasterSunday(currentYear);
            TimeSpan onewWeek = new TimeSpan(7, 0, 0, 0);
            dateRanges.Add(new DateRange(easter.Subtract(onewWeek), easter.Add(onewWeek)));
        }
        return dateRanges;
    }

    // calculate Peak Times for current year
    public static List<DateRange> getPeakTimesForCurrentYear()
    {
        List<DateRange> dateRanges = new List<DateRange>();
        int currentYear = DateTime.Now.Year;
        // 15th of July till 31st of August
        dateRanges.Add(new DateRange(new DateTime(currentYear, 7, 15)
                , new DateTime(currentYear, 8, 31)));
        // 15th of December to 22nd of December
        dateRanges.Add(new DateRange(new DateTime(currentYear, 12, 15)
                , new DateTime(currentYear, 12, 22)));
        // week before and after Easter
        DateTime easter = EasterSunday(currentYear);
        TimeSpan onewWeek = new TimeSpan(7, 0, 0, 0);
        dateRanges.Add(new DateRange(easter.Subtract(onewWeek), easter.Add(onewWeek)));

        return dateRanges;
    }

    public static int CalculateHolidayAllowanceOnRegistration(DateTime startDate)
    {
        if (startDate.Year == DateTime.Now.Year)
        {
            return Convert.ToInt32(Math.Round((double)(365 - startDate.DayOfYear) / 12));
        }
        int years = DateTime.Now.Year - startDate.Year;
        return 30 + Convert.ToInt32(Math.Floor((double)years / 5));
    }

    public static bool isOverlappingHoliday(HolidayRequest existing, HolidayRequest newAdded)
    {
        if (existing.EndDate > DateTime.Now
              && ((existing.EndDate >= newAdded.StartDate && existing.EndDate <= newAdded.EndDate)
              || (existing.StartDate <= newAdded.EndDate && existing.StartDate >= newAdded.StartDate)
              || (existing.StartDate <= newAdded.StartDate && existing.EndDate >= newAdded.EndDate)))
            return true;
        return false;
    }
    public static bool isOverlappingDateRanges(DateRange existing, DateRange newAdded)
    {
        if (existing.EndDate > DateTime.Now
              && ((existing.EndDate >= newAdded.StartDate && existing.EndDate <= newAdded.EndDate)
              || (existing.StartDate <= newAdded.EndDate && existing.StartDate >= newAdded.StartDate)
              || (existing.StartDate <= newAdded.StartDate && existing.EndDate >= newAdded.EndDate)))
            return true;
        return false;
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
        while (from < to.AddDays(1))
        {
            if (!(from.DayOfWeek == DayOfWeek.Saturday || from.DayOfWeek == DayOfWeek.Sunday))
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

    // return name of the month based on a number between 1-12
    public static string getMonthName(int month)
    {
        switch (month)
        {
            case 2:
                return "February";
            case 3:
                return "March";
            case 4:
                return "April";
            case 5:
                return "May";
            case 6:
                return "June";
            case 7:
                return "July";
            case 8:
                return "August";
            case 9:
                return "September";
            case 10:
                return "October";
            case 11:
                return "November";
            case 12:
                return "December";
            default:
                return "January";
        }
    }

    // returns the day number based on the name of the day
    public static int getDayValue(string day)
    {
        switch (day)
        {
            case "Monday":
                return 0;
            case "Tuesday":
                return 1;
            case "Wednesday":
                return 2;
            case "Thursday":
                return 3;
            case "Friday":
                return 4;
            case "Saturday":
                return 5;
            default:
                return 6;
        }
    }

    public static bool isWeekendDay(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
    }

    /* Author: hunter
     * Date Posted: March/2010
     * Date Accessed: 21/02/2020
     * Type: Source code
     * Availability: https://stackoverflow.com/questions/2510383/how-can-i-calculate-what-date-good-friday-falls-on-given-a-year
     */
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
