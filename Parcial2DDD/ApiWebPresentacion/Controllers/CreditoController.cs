using Aplicacion;
using Dominio.Contracts;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebPresentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public CreditoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Registrarcredito")]
        public ActionResult<Credito> Post(Creditorequest creditorequest)
        {
            RegistrarCreditoService _service = new RegistrarCreditoService(_unitOfWork);
            Response response = _service.Ejecutar(creditorequest.Persona, creditorequest.Valor, creditorequest.Fecha, creditorequest.Mesesdeplazo);
            return Ok(response);
        }
    }
}
