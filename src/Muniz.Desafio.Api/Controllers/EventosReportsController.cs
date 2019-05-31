using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Muniz.Desafio.Api.Controllers
{
    [Route("api/Eventos/Relatorio")]
    [ApiController]
    public class EventosReportsController : ControllerBase
    {
        [HttpGet("SensoresRegistrados")]
        public  int Get()
        {
            return 0;
        }
    }
}