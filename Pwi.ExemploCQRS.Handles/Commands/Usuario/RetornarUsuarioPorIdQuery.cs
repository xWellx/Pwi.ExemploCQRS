using System.Collections.Generic;
using MediatR;
using Pwi.ExemploCQRS.Handles.Query;

namespace Pwi.ExemploCQRS.Handles.Commands.Usuario
{
    public class RetornarUsuarioPorNomeCommand : IRequest<IReadOnlyList<UsuarioQuery>>
    {
        public string Nome { get; set; }
    }
}