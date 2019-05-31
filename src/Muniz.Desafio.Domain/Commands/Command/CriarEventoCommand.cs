

using Muniz.Desafio.Domain.Contracts;

namespace Muniz.Desafio.Domain.Commands.Command
{
    public class CriarEventoCommand : ICommand
    {
        /// <summary>
        ///  Data de quando o evento ocorreu em UNIX Timestamp
        /// </summary>
        public long Timestamp { get; set; }
        public string Tag { get; set; }
        public string Valor { get; set; }
    }
}