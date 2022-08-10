using BookStore.Domain.Entities;

namespace BookStore.Services.Interfaces;

public interface IBooksService
{
    Task<IEnumerable<Book>> GetAllAsync(CancellationToken Cancel = default);

    Task<Book?> GetByIdAsync(int id, CancellationToken Cancel = default);

    Task<bool> DeleteAsync(int id, CancellationToken Cancel = default);
}
