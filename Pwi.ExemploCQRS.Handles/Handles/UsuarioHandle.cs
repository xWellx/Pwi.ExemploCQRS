using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pwi.ExemploCQRS.Handles.Commands.Usuario;
using Pwi.ExemploCQRS.Handles.Query;
using Pwi.ExemploCQRS.Repositories.Entities;
using Pwi.ExemploCQRS.Repositories.Usuario;

namespace Pwi.ExemploCQRS.Handles.Handles
{
    public class UsuarioHandle :
    IRequestHandler<AddUsuarioCommand>,
    IRequestHandler<RetornarUsuarioPorNomeCommand, IReadOnlyList<UsuarioQuery>>

    {
        private readonly IMediator _mediatr;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioHandle(IMediator mediatr, IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
            this._mediatr = mediatr;
        }

        public async Task<IReadOnlyList<UsuarioQuery>> Handle(RetornarUsuarioPorNomeCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<UsuarioEntity> listaUsuarioEntity = await _usuarioRepository
                .ConsultarPorNomeAsync(request.Nome);

            return listaUsuarioEntity
                .Select(x => new UsuarioQuery()
                {
                    Email = x.Email,
                    Nome = x.Nome,
                    Sobrenome = x.Sobrenome
                })
                .ToList();
        }

        async Task<Unit> IRequestHandler<AddUsuarioCommand, Unit>.Handle(AddUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioEntity = new UsuarioEntity(
                id: 0,
                nome: request.Nome,
                sobrenome: request.Sobrenome,
                email: request.Email
            );

            await _usuarioRepository.IncluirAsync(usuarioEntity, cancellationToken);

            return Unit.Value;
        }
    }
}