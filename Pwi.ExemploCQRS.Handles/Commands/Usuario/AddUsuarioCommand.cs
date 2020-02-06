using MediatR;

namespace Pwi.ExemploCQRS.Handles.Commands.Usuario
{
    public class AddUsuarioCommand : IRequest
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
    }
}