using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoBCP_API.Data;
using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Service.Impl
{
    public class BaseActivoService : IBaseActivoService
    {
        private DataContext _context;
        private DbSet<BaseActivo> _dbSet;

        public BaseActivoService(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<BaseActivo>();
        }

        public async Task<List<BaseActivo>> GetBaseActivos(string matricula, PaginadoRequest PaginadoResponse)
        {
            int beginRecord = (PaginadoResponse.PageNumber - 1) * PaginadoResponse.PageSize;

            SqlParameter matriculaParam = new SqlParameter
            {
                ParameterName = "MATRICULA",
                Value = matricula,
                Direction = System.Data.ParameterDirection.Input
            };

            SqlParameter pageParam = new SqlParameter
            {
                ParameterName = "PAGE",
                Value = beginRecord,
                Direction = System.Data.ParameterDirection.Input
            };

            SqlParameter sizeParam = new SqlParameter
            {
                ParameterName = "SIZE",
                Value = PaginadoResponse.PageSize,
                Direction = System.Data.ParameterDirection.Input
            };

            var result = await _dbSet.FromSqlRaw("exec OBTENER_BASE_ACTIVO @MATRICULA, @PAGE, @SIZE", matriculaParam, pageParam, sizeParam).ToListAsync();
            if (result != null && result.Count > 0) return result.ToList();

            return null;
        }

        public async Task<List<BaseActivo>> GetAllBaseActivos()
        {
            SqlParameter matriculaParam = new SqlParameter
            {
                ParameterName = "MATRICULA",
                Value = "---",
                Direction = System.Data.ParameterDirection.Input
            };
            var result = await _dbSet.FromSqlRaw("exec OBTENER_BASE_ACTIVO @MATRICULA", matriculaParam).ToListAsync();
            if (result != null && result.Count > 0) return result.ToList();

            return null;
        }
    }
}
