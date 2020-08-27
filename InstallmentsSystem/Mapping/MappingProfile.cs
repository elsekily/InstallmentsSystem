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
            //Domain to API

            CreateMap<Client, ClientResource>();
            CreateMap<Client, ClientResourceWithInstallments>()
                .ForMember(cri => cri.Installments, opt => opt.MapFrom(c =>
                  c.Installments.Select(ci => new InstallmentResourece
                  {
                      Id = ci.Id,
                      StartDate = ci.StartDate,
                      DeviceName = ci.DeviceName,
                      DeviceActualPrice = ci.DeviceActualPrice,
                      PaymentScheme = ci.PaymentScheme,
                      DevicePrice = ci.DevicePrice,
                      FirstInstallment = ci.FirstInstallment,
                      Remaining = ci.Remaining,
                      MontlyPayment = ci.MontlyPayment,
                      DayofPayment = ci.DayofPayment,
                      NextPayment = ci.NextPayment,
                      ClientId = ci.ClientId
                  })));  

            CreateMap<Installment, InstallmentResourece>();
            CreateMap<Installment, InstallmentResoureceWithPayments>()
                .ForMember(irp=>irp.ClientId,opt=>opt.MapFrom(i=>i.Client.Id))
                .ForMember(irp => irp.Payments, opt => opt.MapFrom(
                    i=>i.Payments.Select(ip=> new PaymentResource 
                    {
                        Id = ip.Id,
                        Amount = ip.Amount,
                        MonthNumber = ip.MonthNumber,
                        Date = ip.Date,
                        Detials = ip.Detials,
                        InstallmentId = ip.InstallmentId
                    })));


            //API to Domain

            CreateMap<ClientSaveResource, Client>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.Installments, opt => opt.Ignore());

            CreateMap<InstallmentSaveResource, Installment>()
                .ForMember(i => i.Id, opt => opt.Ignore())
                .ForMember(i => i.StartDate, opt => opt.Ignore())
                .ForMember(i => i.NextPayment, opt => opt.Ignore())
                .ForMember(i => i.Payments, opt => opt.Ignore())
                .ForMember(i => i.Remaining, opt => opt.MapFrom(isr => isr.DevicePrice - isr.FirstInstallment))
                .AfterMap((isr, i) =>
                {
                    i.StartDate = DateTime.Now;
                    var next = DateTime.Now.AddMonths(1);
                    
                    if(DateTime.DaysInMonth(next.Year,next.Month)<i.DayofPayment)
                        i.NextPayment = new DateTime(next.Year, next.AddMonths(1).Month, 1);
                        
                    else
                        i.NextPayment = new DateTime(next.Year,next.Month,i.DayofPayment);
                });

            /*
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
            */
        }
    }
}
