using System;

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
}
