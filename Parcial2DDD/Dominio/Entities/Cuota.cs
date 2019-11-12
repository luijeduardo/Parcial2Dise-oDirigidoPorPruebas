using Dominio.Base;
using System;
using System.Collections.Generic;

namespace Dominio.Entities
{
    public class Cuota : Entity<int>
    {
        public Cuota()
        {

        }
        public Cuota(DateTime fecha, decimal precio, Credito credito)
        {
            this.Fecha = fecha;
            this.Precio = precio;
            this.Credito = credito;
        }
        public DateTime Fecha { get; private set; }
        public decimal Precio { get; private set; }
        public Credito Credito { get; private set; }
    }
}
