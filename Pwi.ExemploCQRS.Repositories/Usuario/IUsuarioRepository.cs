using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Pwi.ExemploCQRS.Repositories.Entities;

namespace Pwi.ExemploCQRS.Repositories.Usuario
{
    public interface IUsuarioRepository
    {
        Task IncluirAsync(UsuarioEntity usuarioEntity, CancellationToken cancellationToken);
        Task AtualizarAsync(UsuarioEntity usuarioEntity, CancellationToken cancellationToken);
        Task<IEnumerable<UsuarioEntity>> ConsultarPorNomeAsync(string nome);
    }
}