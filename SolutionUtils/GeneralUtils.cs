using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class GeneralUtils
{
    public const string ADMIN_ROLE = "Admin";
    public const string PENDING = "pending";
    public const string APPROVED = "approved";
    public const string DECLINED = "declined";

    public const string WARNING_COLOR = "#8a6d3b";
    public const string DANGER_COLOR = "#a94442";
    public const string SUCCESS_COLOR = "#3c763d";

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

}
