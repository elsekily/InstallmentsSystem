using System;


namespace InstallmentsAPI.Entities.Resources;
public class SetNextPayment
{
    public static DateTime Date(int paymentDay, DateTime currentNextPayment)
    {
        var nextMonth = currentNextPayment.AddMonths(1).Month;
        var year = nextMonth != 1 ? currentNextPayment.Year : currentNextPayment.Year + 1;
        var nextMonthDays = DateTime.DaysInMonth(year, nextMonth);

        if (paymentDay > nextMonthDays)
            return new DateTime(year, nextMonth, nextMonthDays);

        return new DateTime(year, nextMonth, paymentDay);
    }
}