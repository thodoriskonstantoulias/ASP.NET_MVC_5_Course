using AutoMapper;
using Movie_Rental.Dtos;
using Movie_Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Rental.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}