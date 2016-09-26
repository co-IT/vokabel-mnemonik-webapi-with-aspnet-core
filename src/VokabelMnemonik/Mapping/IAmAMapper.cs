using System.Collections.Generic;

namespace VokabelMnemonik.Mapping
{
    public interface IAmAMapper<in T> where T : class, new()
    {
        object MapList(IEnumerable<T> entities);
        object MapEntity(T entity);
    }
}