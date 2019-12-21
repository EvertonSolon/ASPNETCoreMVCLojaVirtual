﻿using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.Contracts
{
    public interface IColaboradorRepository : IBaseCrudRepository<Colaborador>
    {
        Colaborador Login(string Email, string Senha);
    }
}
