using FotoQuestGoRepository.Data;
using System;

namespace FotoQuestGoRepository.UnitOfWork
{
    public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository UserRepo { get; }
        int Complete();
    }
}
