namespace Illallangi.FlightLog
{
    using System.Collections.Generic;

    using AutoMapper;

    using Illallangi.LiteOrm;

    public static class RepositoryExtensions
    {
        public static IEnumerable<T> Retrieve<T>(this IRepository<T> repo, dynamic o) where T : class
        {
            return repo.Retrieve(Mapper.DynamicMap<T>(o));
        }
    }
}