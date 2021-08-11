namespace matAppBackEnd.Models{

    public class MatbutikkDatabaseSettings : IMatbutikkDatabaseSettings
    {
        public string ListingsCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMatbutikkDatabaseSettings
    {
        string ListingsCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}