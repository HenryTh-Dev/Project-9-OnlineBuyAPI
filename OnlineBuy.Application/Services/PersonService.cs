using AutoMapper;
using OnlineBuy.Application.DTOs;
using OnlineBuy.Application.DTOs.Validations;
using OnlineBuy.Application.Services.Interfaces;
using OnlineBuy.Domain.Interfaces.Repositories;
using OnlineBuy.Domain.Models;

namespace OnlineBuy.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _mapper= mapper;
            _personRepository = personRepository;
        }
        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO) // transforma a entidade dto em entidade base 
        {
            if (personDTO == null)
                return ResultService.Fail<PersonDTO>("Object must be informed");

            var result = new PersonDTOValidator().Validate(personDTO);

            if (!result.IsValid) //validar no person validator
                return ResultService.RequestError<PersonDTO>("Not valid", result);

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreateAsync(person);
            return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
        }
    }
}
