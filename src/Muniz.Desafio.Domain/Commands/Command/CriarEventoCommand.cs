

using Muniz.Desafio.Domain.Contracts;
using System;

namespace Muniz.Desafio.Domain.Commands.Command
{
    public class CriarEventoCommand : ICommand
    {
        public CriarEventoCommand()
        {
            DataRecebimento = DateTime.Now;
        }

        /// <summary>
        ///  Data de quando o evento ocorreu em UNIX Timestamp
        /// </summary>
        public long Timestamp { get; set; }
        public string Tag { get; set; }
        public string Valor { get; set; }

        /// <summary>
        /// Contem a data que o movimento foi recebido pela API
        /// </summary>
        internal DateTime DataRecebimento { get; set; }

    }
}