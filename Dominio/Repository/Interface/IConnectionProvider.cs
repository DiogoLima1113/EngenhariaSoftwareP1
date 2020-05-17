using System.Data;

namespace EngenhariaSoftware.Domain.Repository.Interface
{
    /// <summary>
    /// Interface que determina as principais funcoes e retornos de um provedor de conexões
    /// </summary>
    public interface IConnectionProvider
    {
        /// <summary>
        /// Estabelece uma conexão com banco de dados com base nas informações da appSetings.Json
        /// </summary>
        /// <returns></returns>
        IDbConnection CreateConnection();
    }
}