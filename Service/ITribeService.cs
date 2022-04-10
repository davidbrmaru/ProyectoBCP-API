using ProyectoBCP_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Service
{
    public interface ITribeService
    {

        Task<List<Tribe>> GetTribe();
        Task<Tribe> GetTribeById(int id);
        Task<Tribe> InsertTribe(Tribe tribe);
        Task<Tribe> UpdateTribe(int id, Tribe tribe);
        Task<Tribe> DeleteAsyncByid(int id, Tribe tribe);
        Task<Tribe> DeleteAsync(int id);


    }
}

