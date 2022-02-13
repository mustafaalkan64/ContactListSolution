using AutoMapper;
using SeturContactList.Core.Dtos;
using SeturContactList.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Persons, PersonDto>().ReverseMap();
            CreateMap<Persons, PersonsWithPersonContractListDto>().ReverseMap();
            CreateMap<PersonContacts, PersonContactDto>().ReverseMap();
            CreateMap<Reports, ReportDto>().ReverseMap();
            CreateMap<ReportDetail, ReportDetailDto>().ReverseMap();
        }
    }
}
