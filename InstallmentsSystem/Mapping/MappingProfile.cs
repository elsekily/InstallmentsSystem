using AutoMapper;
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

            CreateMap<Client, ClientResource>()
                .ForMember(cr => cr.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(cr => cr.ClientNationalId, opt => opt.MapFrom(c => c.ClientNationalId))
                .ForMember(cr => cr.MobileNumber, opt => opt.MapFrom(c => c.MobileNumber))
                .ForMember(cr => cr.ClientName, opt => opt.MapFrom(c => c.ClientName));

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

            CreateMap<ClientSaveResource, Client>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.Installments, opt => opt.Ignore())
                .ForMember(c => c.ClientName, opt => opt.MapFrom(csr => csr.ClientName))
                .ForMember(c => c.ClientNationalId, opt => opt.MapFrom(csr => csr.ClientNationalId))
                .ForMember(c => c.MobileNumber, opt => opt.MapFrom(csr => csr.MobileNumber));

        }
    }
}
