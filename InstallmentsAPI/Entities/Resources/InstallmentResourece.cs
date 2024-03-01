using System;
using System.Collections;


namespace InstallmentsAPI.Entities.Resources;
public class InstallmentResourece
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public string DeviceName { get; set; }
    public int DeviceActualPrice { get; set; }
    public int PaymentScheme { get; set; }
    public int DevicePrice { get; set; }
    public int FirstInstallment { get; set; }
    public int Remaining { get; set; }
    public int MontlyPayment { get; set; }
    public int DayofPayment { get; set; }
    public DateTime NextPayment { get; set; }
    public int ClientId { get; set; }
    public string ClientName { get; set; }
}