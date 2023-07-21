using AutoMapper;
using AutoMapper.QueryableExtensions;
using Livros.Application.DTO;
using Livros.Application.Interfaces;
using Livros.Domain.Commands;
using Livros.Domain.Core.Bus;
using Livros.Domain.Interfaces;

namespace Livros.Application.Services
{
    public class LivroAppService : ILivroAppService
    {
        private readonly IMapper _mapper;
        private readonly ILivroRepository _livroRepository;
        private readonly IMediatorHandler Bus;

        public LivroAppService(IMapper mapper,
                               ILivroRepository livroRepository,
                               IMediatorHandler bus)
        {
            _mapper = mapper;
            _livroRepository = livroRepository;
            Bus = bus;
        }

        public IEnumerable<LivroDTO> GetAll()
        {
            return _livroRepository.GetAll().ProjectTo<LivroDTO>(_mapper.ConfigurationProvider);
        }

        public LivroDTO GetById(int id)
        {
            return _mapper.Map<LivroDTO>(_livroRepository.GetById(id));
        }

        public void Register(LivroDTO livroViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewLivroCommand>(livroViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(LivroDTO livroViewModel)
        {
            var updateCommand = _mapper.Map<UpdateLivroCommand>(livroViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveLivroCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
