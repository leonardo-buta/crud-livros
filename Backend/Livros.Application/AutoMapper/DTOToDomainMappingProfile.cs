using AutoMapper;
using Livros.Application.DTO;
using Livros.Domain.Commands;

namespace Livros.Application.AutoMapper
{
    public class DTOToDomainMappingProfile : Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<LivroDTO, RegisterNewLivroCommand>()
                .ConstructUsing(c => new RegisterNewLivroCommand(c.Nome, c.Autor, c.Categoria, c.Ativo));
            CreateMap<LivroDTO, UpdateLivroCommand>()
                .ConstructUsing(c => new UpdateLivroCommand(c.Id, c.Nome, c.Autor, c.Categoria, c.Ativo));
        }
    }
}
