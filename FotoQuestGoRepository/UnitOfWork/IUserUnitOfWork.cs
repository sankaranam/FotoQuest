using FotoQuestGoRepository.Data;
using System;
using System.Threading.Tasks;

namespace FotoQuestGoRepository.UnitOfWork
{
    public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        Task<int> CompleteAsync();
    }
}
