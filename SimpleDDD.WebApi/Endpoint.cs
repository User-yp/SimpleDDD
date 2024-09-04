namespace SimpleDDD.WebApi;

public static class Endpoint
{
    public static class Order
    {
        private const string Base = $"/{nameof(Order)}";

        public const string Create = Base;
        public const string GetAll = Base;
        public const string Get = $"{Base}/{{id}}";
        public const string GetByName = $"{Base}/{{name}}";
        public const string GetByTableId = $"{Base}/table/{{tableId}}";
        public const string GetByTableName = $"{Base}/tableName/{{tableName}}";
        public const string Delete = $"{Base}/{{id}}";
    }
    public static class Table
    {
        private const string Base = $"/{nameof(Table)}";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id}}";
        public const string GetAll = Base;
        public const string GetByOrderName = $"{Base}/{{orderName}}";
        public const string GetByName = $"{Base}/{{Name}}";
        public const string Delete = $"{Base}/{{id}}";
    }
}
