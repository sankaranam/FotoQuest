using FotoQuestGoRepository.Data;
using System;
using System.Threading.Tasks;

namespace FotoQuestGoRepository.UnitOfWork
{
    public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository UserRepo { get; }
        Task<int> CompleteAsync();
    }
}
