using System;
using System.Text;
using System.Text.RegularExpressions;

public static class GeneralUtils
{
    public static String ADMIN_ROLE = "Admin";

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
