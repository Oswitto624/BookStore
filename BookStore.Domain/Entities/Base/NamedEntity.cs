using BookStore.Domain.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Entities.Base;

public abstract class NamedEntity : Entity, INamedEntity
{
    [Required]
    public string Name { get; set; } = null!;
}
