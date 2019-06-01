namespace Muniz.Desafio.Worker
{
    public class Program
    {
        static void Main(string[] args)
        {
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
