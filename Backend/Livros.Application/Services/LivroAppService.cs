using AutoMapper;
using AutoMapper.QueryableExtensions;
using Livros.Application.DTO;
using Livros.Application.Interfaces;
using Livros.Domain.Commands;
using Livros.Domain.Core.Bus;
using Livros.Domain.Interfaces;
using MediatR;

namespace Livros.Application.Services
{
    public class LivroAppService : ILivroAppService
    {
        private readonly IMapper _mapper;
        private readonly ILivroRepository _livroRepository;
        private readonly IMediatorHandler Bus;
        private readonly IMediator _mediator;

        public LivroAppService(IMapper mapper,
                               ILivroRepository livroRepository,
                               IMediatorHandler bus,
                               IMediator mediator)
        {
            _mapper = mapper;
            _livroRepository = livroRepository;
            Bus = bus;
            _mediator = mediator;
        }

        public async Task<List<LivroDTO>> GetAll()
        {
            var getCommand = new GetListLivrosQuery();
            var data = await _mediator.Send(getCommand);
            return _mapper.Map<List<LivroDTO>>(data);
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
