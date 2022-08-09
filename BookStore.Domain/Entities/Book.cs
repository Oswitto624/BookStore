﻿using BookStore.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain.Entities;

public class Book : NamedEntity
{
    [Required]
    public Author Author { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "Date")]
    public DateTime PublicationDate { get; set; }

    public override string ToString() => $"[{Id}] {Name}, {Author.Name}, {PublicationDate.ToShortDateString()} ";
}
