using System.Data.Entity;

namespace Reporting.DAL.Concrete.EntityFramework.Initiliaser
{
    public class DataBaseInitializer<T> where T : DbContext, new()
    {
        private static bool isDbInitialized = false;
        private static object objLock = new object();

        public static void InitializedDatabase(bool force = false)
        {
            lock (objLock)
            {
                if (!isDbInitialized)
                {
                    Database.SetInitializer<T>(new InitializerIfNotExists<T>());
                    T instance = new T();
                    instance.Database.Initialize(force);
                    isDbInitialized = true;
                }
            }
        }
    }
}




