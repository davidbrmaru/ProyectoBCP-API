﻿using ProyectoBCP_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Service
{
    public interface IRolService
    {

        Task<List<Rol>> GetRol();
        Task<Rol> GetRolById(int id);
        Task<Rol> InsertRol(Rol rol);
        Task<Rol> UpdateRol(int id, Rol rol);
        Task<Rol> DeleteAsyncByid(int id, Rol rol);
        Task<Rol> DeleteAsync(int id);


    }
}