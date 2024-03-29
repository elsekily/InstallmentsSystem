﻿using System.ComponentModel.DataAnnotations;


namespace InstallmentsAPI.Entities.Resources;
public class InstallmentSaveResource
{
    [MaxLength(255)]
    [Required]
    public string DeviceName { get; set; }
    public int DeviceActualPrice { get; set; }
    [Required]
    public int PaymentScheme { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int DevicePrice { get; set; }
    [Required]
    public int FirstInstallment { get; set; }
    [Range(1, int.MaxValue)]
    public int MontlyPayment { get; set; }
    [Required]
    [Range(1, 31)]
    public int DayofPayment { get; set; }
    [Required]
    public int ClientId { get; set; }
}