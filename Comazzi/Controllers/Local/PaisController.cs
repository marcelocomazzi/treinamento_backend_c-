using Comazzi.DB.Local;
using Comazzi.Model;
using Microsoft.AspNetCore.Mvc;

namespace Comazzi.Controllers.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController(PaisServer paisServer) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List(int offset = 0, int limit = 10)
        {
            Sessao sessao = new Sessao
            {
                sessao_id = 1,
                usuario_id = 1
            };

            return Ok(await paisServer.List(sessao, offset, limit));
        }
    }
}
