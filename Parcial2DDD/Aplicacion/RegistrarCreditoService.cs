using Dominio.Contracts;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion
{
    public class RegistrarCreditoService
    {
        readonly IUnitOfWork _unitOfWork;

        public RegistrarCreditoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Response Ejecutar(Personarequest personareq, decimal valordelprestamo, DateTime fecha, int plazo)
        {
            Persona persona = _unitOfWork.PersonaRepository.FindFirstOrDefault(t => t.Cedula == personareq.Cedula);
            Credito credito = _unitOfWork.CreditoRepository.FindFirstOrDefault(t => t.Persona.Id == persona.Id);
            if (credito == null)
            {
                if (new Credito().ValidarPruebasUnitarias(plazo))
                {
                    Credito nuevocredito = new Credito(valordelprestamo, fecha, plazo, persona);
                    _unitOfWork.CreditoRepository.Add(nuevocredito);
                    _unitOfWork.Commit();
                    return new Response() { Mensaje = $"Se registró el credito." };
                }
                else
                    return new Response() { Mensaje = $"No se registró el crédito, falló alguna prueba unitaria." };
            }
            else
            {
                return new Response() { Mensaje = $"La persona ya tiene un crédito." };
            }
        }
    }
    public class Creditorequest
    {
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
        public int Mesesdeplazo { get; set; }
        public Personarequest Persona { get; set; }
    }
}
