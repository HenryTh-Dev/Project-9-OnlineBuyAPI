using OnlineBuy.Application.DTOs;
using OnlineBuy.Domain.Models;
using System;
using AutoMapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBuy.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Person, PersonDTO>();
        }

    }
}
