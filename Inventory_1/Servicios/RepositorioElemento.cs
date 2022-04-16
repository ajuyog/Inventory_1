using Dapper;
using Inventory_1.Models;
using Microsoft.Data.SqlClient;

namespace Inventory_1.Servicios
{
    public interface IRepositorioElemento
    {
        Task Actualizar(Elementos elementos);
        Task CrearElemento(Elementos elementos);
        Task<bool> ExistElemento(int idElement);
        Task<IEnumerable<Elementos>> Obtener();
        Task<Elementos> ObtenerElemento(int idElement);
    }

    public class RepositorioElemento: IRepositorioElemento
    {

        private readonly string connectionStrings;

        public RepositorioElemento(IConfiguration configuration)
        {
            connectionStrings = configuration.GetConnectionString("Connection_2");
        }

        //crear elemento formulario
        
        public async Task CrearElemento(Elementos elementos)
        {
            using var connention = new SqlConnection(connectionStrings);

            var idElement = await connention.QuerySingleAsync<int>(@"INSERT INTO Element (ElementType_idElementType, Element_idElement, description, active) 
                                                                    VALUES (@ElementType_idElementType, @Element_idElement, @description, @active);
                                                                    SELECT SCOPE_IDENTITY();", elementos);

            elementos.idElement = idElement;

        }

        //verificacion de dato

        public async Task<bool> ExistElemento(int idElement)
        {
            using var connention = new SqlConnection(connectionStrings);

            var existElemento = await connention.QueryFirstOrDefaultAsync<int>(@"SELECT 1 FROM Element WHERE idElement = @idElement", new { idElement });

            return existElemento == 1;   
        }

        //lista elementos

        public async Task<IEnumerable<Elementos>> Obtener()
        {
            using var connention = new SqlConnection(connectionStrings);

            return await connention.QueryAsync<Elementos>(@"SELECT idElement, ElementType_idElementType, Element_idElement, description, active FROM Element");
        }

        //Editar elemento

        public async Task Actualizar(Elementos elementos)
        {
            using var connection = new SqlConnection(connectionStrings);

            await connection.ExecuteAsync(@"UPDATE Element SET 
                                            ElementType_idElementType = @ElementType_idElementType,
                                            Element_idElement = @Element_idElement,
                                            codeSecondary = @codeSecondary,
                                            description = @description,
                                            active = @active WHERE idElement = @idElement", elementos);
        }

        //verificacion elemento

        public async Task<Elementos> ObtenerElemento(int idElement)
        {
            using var connection = new SqlConnection(connectionStrings);

            return await connection.QueryFirstOrDefaultAsync<Elementos>(@"SELECT idElement, ElementType_idElementType, Element_idElement, description, active 
                                                                        FROM Element WHERE idElement = @idElement", new { idElement });
        }

    }
}
