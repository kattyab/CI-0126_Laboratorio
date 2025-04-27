using Lab4.Handlers;
using Lab4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly PaisesHandler _paisHandler;

        public PaisesController()
        {
            _paisHandler = new PaisesHandler();
        }

        [HttpGet]
        public List<PaisModel> Get()
        {
            var paises = _paisHandler.ObtenerPaises();
            return paises;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CrearPais(PaisModel pais)
        {
            try
            {
                if (pais == null)
                {
                    return BadRequest();
                }

                PaisesHandler paisesHandler = new PaisesHandler();
                var resultado = paisesHandler.CrearPais(pais);
                return new JsonResult(resultado);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error creando país");
            }
        }
    }
}
