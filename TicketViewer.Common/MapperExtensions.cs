using System;
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

        public static Td MapTo<Ts, Td>(this Ts o, Td destination)
        {
            if (o == null)
            {
                return default(Td);
            }

            return MapperFactory.GetInstance().Map<Ts, Td>(o, destination);
        }

        public static object MapToType(this object o, Type destinationType)
        {
            if (o == null)
            {
                return null;
            }

            return MapperFactory.GetInstance().Map(o, o.GetType(), destinationType);
        }

        public static IList<TDestination> MapCollectionTo<TSource, TDestination>(this IList<TSource> o)
        {
            if (o == null)
            {
                return null;
            }

            return MapperFactory.GetInstance().Map<IList<TSource>, IList<TDestination>>(o);
        }

        public static IEnumerable<TDestination> MapCollectionTo<TSource, TDestination>(this IEnumerable<TSource> o)
        {
            if (o == null)
            {
                return null;
            }

            return MapperFactory.GetInstance().Map<IEnumerable<TSource>, IEnumerable<TDestination>>(o);
        }
    }
}
