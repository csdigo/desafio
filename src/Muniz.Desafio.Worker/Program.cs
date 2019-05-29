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
            catch (System.Exception ex)
            {
                // TODO Disparar e-mail
            }

        }
    }
}
