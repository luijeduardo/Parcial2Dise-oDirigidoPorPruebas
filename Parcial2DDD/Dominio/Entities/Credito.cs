using Dominio.Base;
using System;
using System.Collections.Generic;

namespace Dominio.Entities
{
    public class Credito : Entity<int>
    {
        private Credito Creditotemp;
        public Credito()
        {

        }
        public Credito(decimal valor, DateTime fecha, int mesdeplazo, Persona persona)
        {
            this.Valor = valor;
            this.Fecha = fecha;
            this.Mesesdeplazo = mesdeplazo;
            this.Persona = persona;

            this.Creditotemp = new Credito();
            this.Creditotemp.Valor = this.Valor;
            this.Creditotemp.Fecha = this.Fecha;
            this.Creditotemp.Mesesdeplazo = this.Mesesdeplazo;

            this.Cuotas = ObtenerLasCuotas(this.Creditotemp);
        }
        public decimal Valor { get; private set; }
        public DateTime Fecha { get; private set; }
        public int Mesesdeplazo { get; private set; }
        public Persona Persona { get; private set; }
        public List<Cuota> Cuotas { get; private set; }  = new List<Cuota>();

        public bool ValidarPruebasUnitarias(int plazo)
        {
            if (ValidarMesesDePlazo(plazo) == "El plazo es correcto.")
            {
                return true;
            }
            return false;
        }
        public string ValidarMesesDePlazo(int plazo)
        {
            if (plazo < 1)
                return "El plazo no es válido porque es menor a 1 mes.";
            else if (plazo > 12)
                return "El plazo no es válido, debe ser máximo 12 meses.";
            else
                return "El plazo es correcto.";
        }
        public List<Cuota> ObtenerLasCuotas(Credito credito)
        {
            List<Cuota> listatemp = new List<Cuota>();
            decimal valordelascuotas = credito.Valor / credito.Mesesdeplazo;
            for (int i = 0; i < credito.Mesesdeplazo; i++)
            {
                Cuota cuota;
                if (i == 0)
                {
                    cuota = new Cuota(credito.Fecha.AddMonths(1), valordelascuotas, credito);
                }
                else
                {
                    DateTime ultimafecha = listatemp[i - 1].Fecha;
                    cuota = new Cuota(ultimafecha.AddMonths(1), valordelascuotas, credito);
                }    
                listatemp.Add(cuota);
            }
            return listatemp;
        }
    }
}
