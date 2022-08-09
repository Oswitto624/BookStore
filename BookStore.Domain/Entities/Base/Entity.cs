using BookStore.Domain.Entities.Base.Interfaces;

namespace BookStore.Domain.Entities.Base;

public abstract class Entity : IEntity
{
    public int Id { get; set; }
}
