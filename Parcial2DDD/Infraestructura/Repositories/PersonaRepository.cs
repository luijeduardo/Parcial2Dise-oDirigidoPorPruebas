using Dominio.Entities;
using Dominio.Repositories;
using Infraestructura.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositories
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(IDbContext context)
              : base(context)
        {

        }

    }
}
