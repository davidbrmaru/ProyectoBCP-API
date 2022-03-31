using ProyectoBCP_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trabajo_final_API.Service
{
    public interface IAplicacionService
    {

            public IQueryable<Application> GetAll();
        

    }
}
