﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.Contracts
{
    public interface ILogin<T> where T : class
    {
        T Login(string email, string senha);
    }
}
