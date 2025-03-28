using Dapper;
using MasterNet.Application.Interfaces;
using MasterNet.Application.Perfumes.DTOs;

namespace MasterNet.Infrastructure.Dapper
{
    public class PerfumeDapperRepository : IPerfumeDapperRepository
    {
        private readonly IDapperContext _context;

        public PerfumeDapperRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<PerfumeDapperDto>> ObtenerPerfumesAsync()
        {
            var query = @"
        SELECT Id, Nombre, Descripcion, FechaPublicacion
        FROM Perfumes
        ORDER BY Nombre";

            using var connection = _context.CreateConnection();
            var perfumes = await connection.QueryAsync<PerfumeDapperDto>(query);
            return perfumes.ToList();
        }

    }
}
