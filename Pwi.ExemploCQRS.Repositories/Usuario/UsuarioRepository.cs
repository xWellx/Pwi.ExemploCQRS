using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Pwi.ExemploCQRS.Repositories.Entities;
using Pwi.ExemploCQRS.Repositories.Infra;

namespace Pwi.ExemploCQRS.Repositories.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        EntityContext _entityContext;

        public UsuarioRepository(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }
        public async Task AtualizarAsync(UsuarioEntity usuarioEntity, CancellationToken cancellationToken)
        {
            await Task.Run(() => _entityContext.Update(usuarioEntity), cancellationToken);
            await _entityContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UsuarioEntity>> ConsultarPorNomeAsync(string nome)
        {
            return await Task.FromResult(_entityContext.UsuarioEntity.Where(x => x.Nome.Contains(nome)));
        }

        public async Task IncluirAsync(UsuarioEntity usuarioEntity, CancellationToken cancellationToken)
        {
            await _entityContext.AddAsync(usuarioEntity, cancellationToken);
            await _entityContext.SaveChangesAsync();
        }
    }
}