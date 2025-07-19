using System;
using System.Collections.Generic;

namespace MovieManage.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Password { get; set; } = null!;
}
