﻿using Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Repositories
{
    public interface IAgentRepository
    {
        public Login GetAgentDetails(Login cred);
    }
}
