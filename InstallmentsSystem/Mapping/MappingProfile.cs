﻿using AutoMapper;
using InstallmentsSystem.Entities.Models;
using InstallmentsSystem.Entities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstallmentsSystem.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //API to Domain

            CreateMap<InstallmentSaveResource, Installment>()
                .ForMember(i => i.Id, opt => opt.Ignore())
                .ForMember(i => i.InstallDate, opt => opt.Ignore())
                .ForMember(i => i.NextPayment, opt => opt.Ignore())
                .ForMember(i => i.Payments, opt => opt.Ignore())
                .ForMember(i => i.Clients, opt => opt.Ignore())
                .ForMember(i => i.PaymentScheme, opt => opt.MapFrom(isr => isr.PaymentScheme))
                .ForMember(i => i.FirstInstallment, opt => opt.MapFrom(isr => isr.FirstInstallment))
                .ForMember(i => i.DeviceName, opt => opt.MapFrom(isr => isr.DeviceName))
                .ForMember(i => i.DeviceActualPrice, opt => opt.MapFrom(isr => isr.DeviceActualPrice))
                .ForMember(i => i.DevicePrice, opt => opt.MapFrom(isr => isr.DevicePrice))
                .ForMember(i => i.MontlyPayment, opt => opt.MapFrom(isr => isr.MontlyPayment))
                .ForMember(i => i.Remaining, opt => opt.MapFrom(isr => isr.DevicePrice - isr.FirstInstallment))
                .ForMember(i => i.MontlyPayment, opt => opt.MapFrom(isr => isr.MontlyPayment))
                .AfterMap((isr, i) =>
                {
                    i.InstallDate = DateTime.Now;
                    i.NextPayment = DateTime.Now.AddMonths(1);
                    i.Clients.Add(new InstallmentClients() { ClientId = isr.ClientId });
                });

            CreateMap<PaymentSaveResource, Payment>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Date, opt => opt.Ignore())
                .ForMember(p => p.MonthNumber, opt => opt.Ignore())
                .ForMember(p => p.Amount, opt => opt.MapFrom(psr => psr.Amount))
                .ForMember(p => p.Detials, opt => opt.MapFrom(psr => psr.Detials))
                .AfterMap((psr,p) =>
                {
                    p.Date = DateTime.Now;
                });


        }
    }
}
