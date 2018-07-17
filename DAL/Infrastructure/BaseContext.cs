using DTO.DataAnnotations;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure
{
    public class BaseContext<T>
    {
        public IMongoDatabase Database;
        public string DataBaseName;
        string conexaoMongoDB = "mongodb://localhost:27017";
        public BaseContext()
        {
            
            var cliente = new MongoClient(conexaoMongoDB);
            Database = cliente.GetDatabase("CurrentBase");
        }

        public IMongoCollection<T> CurrentType
        {
            get
            {
                var current = Database.GetCollection<T>(GetTableName<T>());
                return current;
            }
        }

        protected string GetTableName<T>()
        {
            return 
            typeof(T).GetCustomAttribute<TableName>().Nome ;
        }
    }
}
