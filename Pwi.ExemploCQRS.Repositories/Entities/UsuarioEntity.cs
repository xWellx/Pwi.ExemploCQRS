using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pwi.ExemploCQRS.Repositories.Entities
{
    [Table("TB_USUARIO")]
    public class UsuarioEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public UsuarioEntity(int id, string nome, string sobrenome, string email)
        {
            this.Email = email;
            this.Sobrenome = sobrenome;
            this.Nome = nome;
            this.Id = id;
        }

        internal UsuarioEntity()
        {

        }
    }
}