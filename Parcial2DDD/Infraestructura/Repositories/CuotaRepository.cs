using Dominio.Entities;
using Dominio.Repositories;
using Infraestructura.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositories
{
    public class CuotaRepository : GenericRepository<Cuota>, ICuotaRepository
    {
        public CuotaRepository(IDbContext context)
              : base(context)
        {

        }

    }
}
