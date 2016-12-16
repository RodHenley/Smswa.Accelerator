using System.Configuration;
using System.Reflection;
using DbUp;
using DbUp.Engine;

namespace smswa.accelerator.data.upgrade
{
    public class Updater
    {
        ConnectionStringSettings connectionString;

        public Updater()
        {
            connectionString = ConfigurationManager.ConnectionStrings["accelerator"];
        }

        public DatabaseUpgradeResult UpdateToCurrent()
        {
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString.ConnectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            return upgrader.PerformUpgrade();
        }
    }
}
