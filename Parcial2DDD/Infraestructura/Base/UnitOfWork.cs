using Dominio.Contracts;
using Dominio.Repositories;
using Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infraestructura.Base
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        private ICreditoRepository _creditoRepository;
        private IPersonaRepository _personaRepository;
        private ICuotaRepository _cuotaRepository;
        public ICreditoRepository CreditoRepository { get { return _creditoRepository ?? (_creditoRepository = new CreditoRepository(_dbContext)); } }
        public IPersonaRepository PersonaRepository { get { return _personaRepository ?? (_personaRepository = new PersonaRepository(_dbContext)); } }
        public ICuotaRepository CuotaRepository { get { return _cuotaRepository ?? (_cuotaRepository = new CuotaRepository(_dbContext)); } }

        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }
    }
}
