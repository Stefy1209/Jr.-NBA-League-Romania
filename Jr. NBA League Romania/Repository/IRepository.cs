using Jr._NBA_League_Romania.Domain;

namespace Jr._NBA_League_Romania.Repository;

/// <summary>
/// CRUD operations repository interface.
/// </summary>
/// <typeparam name="TId">Type TEntity must have an attribute of type TId.</typeparam>
/// <typeparam name="TEntity">Type of entity saved in repository.</typeparam>
public interface IRepository<in TId, TEntity> where TEntity : Entity<TId>
{
    /// <summary>
    /// Returns a nullable entity of type TEntity with the given id, or null if not found.
    /// </summary>
    /// <param name="id">The id of the entity to be returned. Must not be null.</param>
    /// <returns>A nullable TEntity (TEntity?), which may be null if no entity with the given id is found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the id is null.</exception>
    TEntity? FindOne(TId? id);
    
    /// <summary>
    /// Returns all entities of type TEntity.
    /// </summary>
    /// <returns>A collection of TEntity objects.</returns>
    IEnumerable<TEntity> FindAll();
    
    /// <summary>
    /// Saves the given entity in the repository.
    /// </summary>
    /// <param name="entity">The given entity to be saved. Must not be null.</param>
    /// <returns>Null if the entity is saved, the entity otherwise(id already exists).</returns>
    /// <exception cref="ArgumentNullException">Thrown when the entity is null.</exception>
    TEntity? Save(TEntity? entity);
    
    /// <summary>
    /// Deletes the entity with the given id from repository.
    /// </summary>
    /// <param name="id">The id of the entity to be deleted. Must not be null.</param>
    /// <returns>The entity with the given id if it is deleted, null otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when id is null.</exception>
    TEntity? Delete(TId? id);
}