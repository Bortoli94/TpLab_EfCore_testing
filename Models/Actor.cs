using System;
using System.Collections.Generic;

namespace TPLabIV.Models;

public partial class Actor
{
    public int Id { get; set; }

    public string ActorName { get; set; } = null!;

    public DateOnly ActorBirthdate { get; set; }

    public string ActorPicture { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
