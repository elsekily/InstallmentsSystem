﻿using System;

namespace InstallmentsAPI.Entities.Models;

public class Payment
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public int MonthNumber { get; set; }
    public DateTime Date { get; set; }
    public string Detials { get; set; }
    public int InstallmentId { get; set; }
    public Installment Installment { get; set; }
}