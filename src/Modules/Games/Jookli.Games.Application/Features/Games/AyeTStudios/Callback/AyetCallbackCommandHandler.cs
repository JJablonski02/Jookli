using Jookli.Games.Application.Configuration.Command;
using Jookli.Games.Domain.Entities.Game.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Application.Features.Games.AyeTStudios.Callback
{
    internal class AyetCallbackCommandHandler : ICommandHandler<AyetCallbackCommand>
    {
        private readonly IGameRepository _gameRepository;
        public AyetCallbackCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public Task<Unit> Handle(AyetCallbackCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
