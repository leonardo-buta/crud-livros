using AutoMapper;
using Livros.Application.DTO;
using Livros.Domain.Models;

namespace Livros.Application.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Livro, LivroDTO>();
        }
    }
}
