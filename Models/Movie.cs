using System;
using System.Collections.Generic;

namespace MovieManage.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public DateOnly ReleaseDate { get; set; }
}
