using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace Illallangi.FlightLogPS.SQLite
{
    public static class SQLiteSelectCommandExtensions
    {
        public static SQLiteSelectCommand<T> Column<T>(this SQLiteSelectCommand<T> select, string column, object value = null) where T : new()
        {
            select.Columns.Add(column, value);
            return select;
        }

        public static SQLiteSelectCommand<T> FloatColumn<T>(this SQLiteSelectCommand<T> select, string column, Action<T, float> func, object value = null) where T : new()
        {
            select.FloatMap.Add(column, func);
            return select.Column(column, value);
        }

        public static SQLiteSelectCommand<T> Column<T>(this SQLiteSelectCommand<T> select, string column, Action<T, int> func, object value = null) where T : new()
        {
            select.IntMap.Add(column, func);
            return select.Column(column, value);
        }

        public static SQLiteSelectCommand<T> Column<T>(this SQLiteSelectCommand<T> select, string column, Action<T, string> func, object value = null) where T : new()
        {
            select.StringMap.Add(column, func);
            return select.Column(column, value);
        }

        public static IEnumerable<T> Go<T>(this SQLiteSelectCommand<T> select) where T : new()
        {
            using (var reader = select.CreateCommand().ExecuteReader())
            while (reader.HasRows && reader.Read())
            {
                var result = new T();
                foreach (var kvm in select.IntMap)
                {
                    var ordinal = reader.GetOrdinal(kvm.Key);
                    var int32 = reader.GetInt32(ordinal);
                    kvm.Value(result, int32);
                }
                foreach (var kvm in select.FloatMap)
                {
                    kvm.Value(result, reader.GetFloat(reader.GetOrdinal(kvm.Key)));
                }
                foreach (var kvm in select.StringMap)
                {
                    kvm.Value(result, reader.GetString(reader.GetOrdinal(kvm.Key)));
                }

                yield return result;
                //yield return new Country
                //{
                //    Id = reader.GetInt32(0),
                //    Name = reader.GetString(1),
                //    Cities = reader.GetInt32(2),
                //    Airports = reader.GetInt32(3),
                //};
            }
        }

        public static string GetColumnNames<T>(this SQLiteSelectCommand<T> select) where T : new()
        {
            return string.Join(", ", select.Columns.Keys.Select(k => string.Format("[{0}].[{1}] as {1}", select.Table, k)));
        }

        public static string GetWhereClause<T>(this SQLiteSelectCommand<T> select) where T : new()
        {
            return select.Columns.Any(kvp => null != kvp.Value)
                ? string.Concat(" WHERE ",
                                string.Join(" AND ", select.Columns
                                    .Where(kvp => null != kvp.Value)
                                    .Select(kvp => string.Format("[{0}].[{1}]=@{1}", select.Table, kvp.Key))))
                : string.Empty;
        }

        public static string GetSql<T>(this SQLiteSelectCommand<T> select) where T : new()
        {
            return string.Format("SELECT {0} FROM {1}{2};",
                select.GetColumnNames(),
                select.Table,
                select.GetWhereClause());
        }

        public static SQLiteCommand CreateCommand<T>(this SQLiteSelectCommand<T> select) where T : new()
        {
            var cm = select.Connection.CreateCommand();
            cm.CommandText = select.GetSql();
            foreach (var column in select.Columns.Where(kvp => null != kvp.Value))
            {
                cm.Parameters.Add(new SQLiteParameter(string.Concat("@", column.Key), column.Value));
            }
            return cm;
        }
    }
}