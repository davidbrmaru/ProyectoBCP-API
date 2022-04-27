using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Service
{
    public interface ITribeService
    {

        Task<TribeRequest> GetTribe(PaginadoRequest PaginadoResponse);
        Task<List<Tribe>> GetAllTribe();
        Task<Tribe> GetTribeById(int id);
        Task<Tribe> InsertTribe(Tribe tribe);
        Task<Tribe> UpdateTribe(int id, Tribe tribe);
        Task<Tribe> DeleteAsyncByid(int id, Tribe tribe);
        Task<Tribe> DeleteAsync(int id);


    }
}

