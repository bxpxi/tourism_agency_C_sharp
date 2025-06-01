using System.Configuration;
using System.Data;
using System.Data.SQLite;
using log4net;

namespace Repository
{
    public static class JdbcUtils
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(JdbcUtils));

        public static IDbConnection getConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Default"]?.ConnectionString;
            if (connectionString == null)
            {
                logger.Error("Connection string is null. Exiting.");
                return null;
            }
            logger.Info("Connection string: " + connectionString);
            IDbConnection instance = new SQLiteConnection(connectionString);
            instance.Open();
            return instance;
        }
    }
}