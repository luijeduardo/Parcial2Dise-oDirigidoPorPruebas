using Dominio.Contracts;
using Dominio.Entities;
using System;

namespace Aplicacion
{
    public class RegistrarPersonaService
    {
        readonly IUnitOfWork _unitOfWork;

        public RegistrarPersonaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Response Ejecutar(Personarequest personarequest)
        {
            Persona persona = _unitOfWork.PersonaRepository.FindFirstOrDefault(t => t.Cedula == personarequest.Cedula);
            if (persona == null)
            {
                Persona personanueva = new Persona(personarequest.Cedula, personarequest.Nombres);
                _unitOfWork.PersonaRepository.Add(personanueva);
                _unitOfWork.Commit();
                return new Response() { Mensaje = $"Se registró la persona." };
            }
            else
            {
                return new Response() { Mensaje = $"La persona ya existe." };
            }
        }
    }
    public class Personarequest
    {
        public string Cedula { get; set; }
        public string Nombres { get; set; }
    }
    public class Response
    {
        public string Mensaje { get; set; }
    }
}
