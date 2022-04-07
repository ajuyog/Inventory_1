namespace Inventory_1.Servicios
{

    public interface IRepositorioPersona
    {

    }
    public class RepositorioPersona: IRepositorioPersona
    {
        private readonly string connectionStrings;

        public RepositorioPersona(IConfiguration configuration)
        {

            connectionStrings = configuration.GetConnectionString("Connection_2");

        }

    }
}
