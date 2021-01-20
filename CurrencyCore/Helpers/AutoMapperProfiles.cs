using AutoMapper;
using CurrencyCore.DTOs;
using CurrencyEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyCore.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Currency, CurrencyDto>();
        }
    }
}
