using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muniz.Domain.Desafio.Entities;
using Muniz.Domain.Desafio.Enums;
using System;

namespace Muniz.Domain.Test
{
    [TestClass]
    public class EventoTest
    {
        [TestMethod, Description("Criando um evento do tipo texto")]
        public void CriarEventoDoTipoTexto()
        {
            var evento = new Evento("brasil.sudeste.sensor01", "abc", DateTime.Now.Ticks, DateTime.Now);

            Assert.AreEqual(evento.EventoTipo, EventoTipo.Texto);
        }

        [TestMethod, Description("Criando um evento com erro")]
        public void CriarEventoComErro()
        {
            var evento = new Evento("brasil.sudeste.sensor01", "", DateTime.Now.Ticks, DateTime.Now);

            Assert.AreEqual(evento.EventoEstado, EventoEstado.Erro);
        }

        [TestMethod, Description("Criando um evento que foi processado do tipo Texto")]
        public void CriarEventoProcessadoTexto()
        {
            var evento = new Evento("brasil.sudeste.sensor01", "tudo certo", DateTime.Now.Ticks, DateTime.Now);

            Assert.AreEqual(evento.EventoEstado, Desafio.Enums.EventoEstado.Processado);
            Assert.AreEqual(evento.EventoTipo, EventoTipo.Texto);
        }

        [TestMethod, Description("Criando um evento que foi processado do tipo Número")]
        public void CriarEventoProcessadoNumero()
        {
            var evento = new Evento("brasil.sudeste.sensor01", "1", DateTime.Now.Ticks, DateTime.Now);

            Assert.AreEqual(evento.EventoEstado, Desafio.Enums.EventoEstado.Processado);
            Assert.AreEqual(evento.EventoTipo, EventoTipo.Numero);
        }
    }
}
