namespace Flightly.Helpers.Interfaces
{
    public interface IHelpers
    {
        IQueryable<T> ApplySorting<T>(IQueryable<T> query, string? sortBy, bool isDescending);
    }
}
