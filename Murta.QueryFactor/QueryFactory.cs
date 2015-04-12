using Murta.QueryFactor;
using Murta.QueryFactor.Annotations;
using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Murta.QueryFactory
{
    public enum Databaseoperation
    {
        Update,
        Insert,
        Delete,
        Select,
        Filter
    }

    public static partial class Factory
    {
        public static string GetQuery<T>(Databaseoperation operation)
        {            
            var query = string.Empty;
            var obj = Utils.GetGenericInstance<T>();
            
            switch (operation)
            {
                case Databaseoperation.Select:
                    query = GenerateSelectQuery<T>(obj);
                    break;
                default:
                    throw new Exception("This operation requires a list of parameters.");
                    break;
            }
            
            return query;
        }

        public static string GetQuery<T>(Databaseoperation operation, ref List<string> parametersName)
        {
            var query = string.Empty;
            var obj = Utils.GetGenericInstance<T>();
            
            switch (operation)
            {
                case Databaseoperation.Update:
                    query = GenerateUpdateQuery<T>(obj, ref parametersName);
                    break;
                case Databaseoperation.Insert:
                    query = GenerateInsertQuery<T>(obj, ref parametersName);
                    break;
                case Databaseoperation.Delete:
                    query = GenerateDeleteQuery<T>(obj, ref parametersName);
                    break;
                case Databaseoperation.Select:
                    query = GenerateSelectQuery<T>(obj);
                    break;
                case Databaseoperation.Filter:
                    query = GenerateFilterQuery<T>(obj, ref parametersName);
                    break;
            }

            return query;
        }        

        private static string GenerateUpdateQuery<T>(T obj, ref List<string> parametersName)
        {
            StringBuilder query = new StringBuilder();
            var table = TableAttributeManipulator.GetValue<T>(obj);
            var columns = ColumnAttributeCollector.GetValues<T>(obj);
            var whereClauses = WhereClauseAttributeCollector.GetValues<T>(obj);

            query.Append("UPDATE " + table.NameTable + " SET ");
            foreach (var item in columns.Select((value, i) => new { i, value }))
            {
                if (item.value.IsUsedInsertOrUpdateOperation)
                {
                    var columnName = item.value;
                    if (!item.value.IsForeignKey)
                    {
                        parametersName.Add("@UP_" + columnName.NameColumn + "_" + table.NameTable);
                        query.Append(table.NameTable + "." + columnName.NameColumn + " = @UP_" + columnName.NameColumn + "_" + table.NameTable);
                    }
                    else
                    {
                        parametersName.Add("@UP_" + columnName.ForeignKeyName + "_" + table.NameTable);
                        query.Append(table.NameTable + "." + columnName.ForeignKeyName + " = @UP_" + columnName.ForeignKeyName + "_" + table.NameTable);
                    }

                    query.Append(", ");
                }                
            }

            Utils.ChangeLastCollumnToEndParentesis(ref query, ' ');
            CreateWhereClause(whereClauses, query, table.NameTable, ref parametersName);
            return query.ToString();
        }

        private static string GenerateInsertQuery<T>(T obj, ref List<string> parametersName)
        {
            StringBuilder query = new StringBuilder();
            var table = TableAttributeManipulator.GetValue<T>(obj);
            var columns = ColumnAttributeCollector.GetValues<T>(obj);

            query.Append("INSERT INTO " + table.NameTable + "(");
            foreach (var item in columns.Select((value, i) => new { i, value }))
            {
                if (!item.value.IsSerial)
                {
                    if (item.value.IsUsedInsertOrUpdateOperation)
                    {
                        var columnName = item.value;

                        if (!item.value.IsForeignKey)
                            query.Append(columnName.NameColumn);
                        else
                            query.Append(columnName.ForeignKeyName);

                        query.Append(", ");   
                    }
                }
            }

            Utils.ChangeLastCollumnToEndParentesis(ref query, ')');
            query.Append(" VALUES (");

            foreach (var item in columns.Select((value, i) => new { i, value }))
            {
                if (!item.value.IsSerial)
                {
                    if (item.value.IsUsedInsertOrUpdateOperation)
                    {
                        var columnName = item.value;

                        if (!item.value.IsForeignKey)
                        {
                            parametersName.Add("@" + columnName.NameColumn);
                            query.Append("@" + columnName.NameColumn);
                        }
                        else
                        {
                            parametersName.Add("@" + columnName.ForeignKeyName);
                            query.Append("@" + columnName.ForeignKeyName);
                        }

                        query.Append(", ");
                    }
                }
            }
            Utils.ChangeLastCollumnToEndParentesis(ref query, ')');
            return query.ToString();
        }

        private static string GenerateDeleteQuery<T>(T obj, ref List<string> parametersName)
        {
            StringBuilder query = new StringBuilder();
            var table = TableAttributeManipulator.GetValue<T>(obj);
            var whereClauses = WhereClauseAttributeCollector.GetValues<T>(obj);
            query.Append("DELETE FROM " + table.NameTable);
            CreateWhereClause(whereClauses, query, table.NameTable, ref parametersName);
            return query.ToString();
        }

        private static string GenerateSelectQuery<T>(T obj)
        {
            var table = TableAttributeManipulator.GetValue<T>(obj);
            var columns = ColumnAttributeCollector.GetValues<T>(obj);
            var joins = JoinAttributeCollector.GetValues<T>(obj);

            StringBuilder query = new StringBuilder();
            query.Append("SELECT ");

            foreach (var item in columns.Select((value, i) => new { i, value }))
            {
                var columnName = item.value;

                if (columnName.NameColumn.IndexOf(".") == -1)
                    query.Append(table.NameTable + "." + columnName.NameColumn);
                else
                    query.Append(columnName.NameColumn);

                query.Append((columns.Count - 1 != item.i) ? ", " : " ");
            }

            query.Append("FROM " + table.NameTable);
            CreateJoins(joins, query);
            return query.ToString();
        }

        private static string GenerateFilterQuery<T>(T obj, ref List<string> parametersName)
        {
            var table = TableAttributeManipulator.GetValue<T>(obj);
            var whereClauses = WhereClauseAttributeCollector.GetValues<T>(obj);
            StringBuilder query = new StringBuilder(GenerateSelectQuery<T>(obj));
            CreateWhereClause(whereClauses, query, table.NameTable, ref parametersName);
            return query.ToString();
        }

        private static void CreateWhereClause(List<WhereClauseAttribute> whereClauses, StringBuilder query, string table, ref List<string> parametersName)
        {
            if (whereClauses.Count != 0)
            {
                query.Append(" WHERE ");

                foreach (var item in whereClauses.Select((value, i) => new { i, value }))
                {
                    var columnName = item.value;
                    parametersName.Add("@" + columnName.NameColumn + "_" + table);
                    query.Append(table + "." + columnName.NameColumn + " = @" + columnName.NameColumn + "_" + table);
                    query.Append((whereClauses.Count - 1 != item.i) ? " AND " : " ");
                }
            }
        }

        private static void CreateJoins(List<JoinAttribute> joins, StringBuilder query)
        {
            if (joins.Count != 0)
            {
                foreach (var item in joins.Select((value, i) => new { i, value }))
                {
                    var join = item.value;
                    query.Append(" " + join.TypeJoin + " " + join.TableB + 
                        " ON " + join.TableA + "." + join.FieldA + " = " + join.TableB + "." + join.FieldB);
                }
            }
        }
        
    }
}
