using System;
using System.Collections.Generic;

namespace Banco.Server.Models;

public partial class LoginAttempt
{
    public string IpAddress { get; set; } = null!;

    public int FailedAttempts { get; set; }

    public DateTime? LockoutTime { get; set; }
}
