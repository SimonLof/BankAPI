﻿using AutoMapper;
using BankApp.Domain.DTO;
using BankApp.Domain.Entities;

namespace BankApp.Domain.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionViewDTO>();

            CreateMap<TransactionCreateDTO, Transaction>();
        }
    }
}
