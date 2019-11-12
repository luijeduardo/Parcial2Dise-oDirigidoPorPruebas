using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion;
using Dominio.Contracts;
using Dominio.Entities;
using Infraestructura;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1.ApiWebPresentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        public PersonaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Registrarpersona")]
        public ActionResult<Personarequest> Post(Personarequest personarequest)
        {
            RegistrarPersonaService _service = new RegistrarPersonaService(_unitOfWork);
            Response response = _service.Ejecutar(personarequest);
            return Ok(response);
        }
    }
}