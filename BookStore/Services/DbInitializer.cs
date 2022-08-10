using BookStore.DAL.Context;
using BookStore.Data;
using BookStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services;

public class DbInitializer : IDbInitializer
{
    private readonly BookStoreDB db;
    private readonly ILogger<DbInitializer> logger;

    public DbInitializer(BookStoreDB Db, ILogger<DbInitializer> Logger)
    {
        db = Db;
        logger = Logger;
    }
    public async Task<bool> RemoveAsync(CancellationToken Cancel = default)
    {
        logger.LogInformation("Удаление БД...");
        var removed = await db.Database.EnsureDeletedAsync(Cancel).ConfigureAwait(false);

        if (removed)
            logger.LogInformation("БД удалена успешно");
        else
            logger.LogInformation("Удаление БД не требуется (отсутствует на сервере).");
        return removed;
    }

    public async Task InitializeAsync(bool RemoveBefore = false, CancellationToken Cancel = default)
    {
        logger.LogInformation("Инициализация БД..");

        if (RemoveBefore)
            await RemoveAsync(Cancel).ConfigureAwait(false);


        var pending_migrations = await db.Database.GetPendingMigrationsAsync(Cancel).ConfigureAwait(false);
        if (pending_migrations.Any())
        {
            logger.LogInformation("Выполнение миграции БД...");
            await db.Database.MigrateAsync(Cancel).ConfigureAwait(false);
            logger.LogInformation("Миграция БД выполнена успешно.");
        }
        else
            logger.LogInformation("Миграция БД не требуется");

        await InitializeTestDataAsync(Cancel).ConfigureAwait(false);

        logger.LogInformation("Инициализация БД выполнена успешно.");
    }

    private async Task InitializeTestDataAsync(CancellationToken Cancel = default)
    {
        if (await db.Author.AnyAsync(Cancel).ConfigureAwait(false))
        {
            logger.LogInformation("В базе данных есть авторы - в инициализации тестовыми данными не нуждается");
            return;
        }

        logger.LogInformation("Инициализация тестовыми данными...");

        logger.LogInformation("Добавление авторов...");
        await using (var transaction = await db.Database.BeginTransactionAsync(Cancel))
        {
            await db.Author.AddRangeAsync(TestData.Authors, Cancel).ConfigureAwait(false);

            await db.SaveChangesAsync(Cancel).ConfigureAwait(false);

            await transaction.CommitAsync(Cancel).ConfigureAwait(false);
        }

        logger.LogInformation("Добавление книг...");
        await using (var transaction = await db.Database.BeginTransactionAsync(Cancel))
        {
            await db.Books.AddRangeAsync(TestData.Books, Cancel).ConfigureAwait(false);

            await db.SaveChangesAsync(Cancel).ConfigureAwait(false);

            await transaction.CommitAsync(Cancel).ConfigureAwait(false);
        }
    }
}
