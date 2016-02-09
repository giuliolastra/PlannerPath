using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectONE
{
    class SqlConnector
    {
        public String Server { get; }
        public String Database { get; }
        public String Username { get; }
        public String Password { get; }

        public SqlConnector()
        {
            this.Server = GetServer();
            this.Database = GetDBName();
            this.Username = GetUsername();
            this.Password = GetPassword();
        }

        /// <summary>
        /// If configuration file already exists, returns username
        /// </summary>
        /// <returns>username if config file exists, null otherwise</returns>
        private static string GetUsername()
        {
            if (SqlConnector.ConfigFileExists() == false)
                return null;

            string[] lines = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + @"\mssql.conf");
            return lines[0].Replace("USERNAME: ", "");
        }

        /// <summary>
        /// If configuration file already exists, returns password
        /// </summary>
        /// <returns>password if config file exists, null otherwise</returns>
        private static string GetPassword()
        {
            if (SqlConnector.ConfigFileExists() == false)
                return null;

            string[] lines = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + @"\mssql.conf");
            return lines[1].Replace("PASSWORD: ", "");
        }

        /// <summary>
        /// If configuration file already exists, returns db name
        /// </summary>
        /// <returns>db name if config file exists, null otherwise</returns>
        private static string GetDBName()
        {
            if (SqlConnector.ConfigFileExists() == false)
                return null;

            string[] lines = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + @"\mssql.conf");
            return lines[2].Replace("DBNAME: ", "");
        }

        /// <summary>
        /// If configuration file already exists, returns server
        /// </summary>
        /// <returns>server if config file exists, null otherwise</returns>
        private static string GetServer()
        {
            if (SqlConnector.ConfigFileExists() == false)
                return null;

            string[] lines = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + @"\mssql.conf");
            return lines[3].Replace("SERVER: ", "");
        }

        /// <summary>
        /// Returns true if configuration file already exists
        /// </summary>
        /// <returns></returns>
        private static bool ConfigFileExists()
        {
            return File.Exists(Directory.GetCurrentDirectory() + @"\mssql.conf");
        }
    }
}
