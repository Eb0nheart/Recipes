namespace Recipes.API.Repositories;

public interface Repository<T>
{
    Task<T> GetAsync(int Id);

    Task<List<T>> GetAsync();

    /// <summary>
    /// Update if non-existant, otherwise saves as new recipe.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Task SaveAsync(T item);

    Task DeleteAsync(T item);
}