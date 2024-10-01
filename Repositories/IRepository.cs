using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    /// <summary>
    /// Interface genérica para repositórios.
    /// </summary>
    /// <typeparam name="T">O tipo da entidade que o repositório gerenciará.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Obtém todas as entidades assíncronamente.
        /// </summary>
        /// <returns>Uma lista de entidades do tipo <typeparamref name="T"/>.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Obtém uma entidade pelo seu ID assíncronamente.
        /// </summary>
        /// <param name="id">O ID da entidade a ser obtida.</param>
        /// <returns>A entidade do tipo <typeparamref name="T"/> correspondente ao ID.</returns>
        Task<T> GetByIdAsync(string id);

        /// <summary>
        /// Adiciona uma nova entidade assíncronamente.
        /// </summary>
        /// <param name="entity">A entidade a ser adicionada.</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Atualiza uma entidade existente assíncronamente.
        /// </summary>
        /// <param name="entity">A entidade com as novas informações.</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Exclui uma entidade pelo seu ID assíncronamente.
        /// </summary>
        /// <param name="id">O ID da entidade a ser excluída.</param>
        Task DeleteAsync(string id);
    }
}