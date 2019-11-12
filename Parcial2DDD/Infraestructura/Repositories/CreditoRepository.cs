using Dominio.Entities;
using Dominio.Repositories;
using Infraestructura.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositories
{
    public class CreditoRepository : GenericRepository<Credito>, ICreditoRepository
    {
        public CreditoRepository(IDbContext context)
              : base(context)
        {

        }

    }
}
