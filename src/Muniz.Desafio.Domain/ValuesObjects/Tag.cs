using System.Linq;

namespace Muniz.Desafio.Domain.ValuesObjects
{
    public class Tag
    {
        public Tag(string tag)
        {
            var aux = tag.Split('.');

            // Verificando se o  formato é valido
            if (aux.Count() != 3)
                return;

            Pais = aux[0];
            Regiao = aux[1];
            Sensor = aux[2];
        }

        public string Pais { get; private set; }
        public string Regiao { get; private set; }
        public string Sensor { get; private set; }

        public bool IsValid()
        {
            return
                string.IsNullOrWhiteSpace(Pais) &&
                string.IsNullOrWhiteSpace(Pais) &&
                string.IsNullOrWhiteSpace(Pais);
        }
    }
}
