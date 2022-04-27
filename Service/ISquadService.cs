﻿using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Service
{
    public interface ISquadService
    {
        Task<SquadRequest> GetSquad(PaginadoRequest PaginadoResponse);
        Task<List<Squad>> GetAllSquad();
        Task<Squad> GetSquadById(int id);
        Task<Squad> InsertSquad(Squad squad);
        Task<Squad> UpdateSquad(int id, Squad squad);
        Task<Squad> DeleteAsyncByid(int id, Squad squad);
        Task<Squad> DeleteAsync(int id);
    }
}