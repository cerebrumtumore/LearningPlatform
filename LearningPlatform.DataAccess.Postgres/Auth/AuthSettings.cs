using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DataAccess.Postgres.Auth;

public class AuthSettings
{
    public string SecretKey { get; set; }
    public TimeSpan Expires { get; set; }
    
}

