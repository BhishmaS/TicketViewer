using System.Collections.Generic;

namespace TicketViewer.Common
{
    public static class MapperExtensions
    {
        public static T MapTo<T>(this object o)
        {
            if (o == null)
            {
                return default(T);
            }

            return MapperFactory.GetInstance().Map<T>(o);
        }

        public static IList<TDestination> MapCollectionTo<TSource, TDestination>(this IList<TSource> o)
        {
            if (o == null)
            {
                return null;
            }

            return MapperFactory.GetInstance().Map<IList<TSource>, IList<TDestination>>(o);
        }
    }
}
