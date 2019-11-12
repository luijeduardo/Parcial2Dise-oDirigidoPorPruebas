using Dominio.Repositories;
using System;

namespace Dominio.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICreditoRepository CreditoRepository { get; }
        IPersonaRepository PersonaRepository { get; }
        ICuotaRepository CuotaRepository { get; }
        int Commit();
    }
}
