using System;

namespace Muniz.Desafio.Worker
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Iniciando o Worker");
            try
            {
                Startup.Init();
            }
            catch
            {
                // TODO Disparar e-mail
            }

        }
    }
}
