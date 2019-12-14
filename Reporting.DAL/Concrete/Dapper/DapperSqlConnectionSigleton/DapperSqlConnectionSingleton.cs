using System.Data.SqlClient;

namespace Reporting.DAL.Concrete.Dapper.DapperSqlConnectionSigleton
{
    class DapperSqlConnectionSingleton
    {


        public class Session
        {
            private static volatile Session _Instance;
            private static object _lockThis = new object();

            private Session()
            {

            }

            public static Session GetSessionInstance()
            {
                if (_Instance == null)
                {
                    lock (_lockThis)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new Session();
                        }
                    }
                }
                return _Instance;
            }

            public SqlConnection thisConn { get; set; }
        }

        // ilk acilista olusturmak  Session.GetSessionInstance().thisConn = new SqlConnection();
        // Yukarıdaki gibi singleton instance oluşturduk.Uygulamanın heryerinde
        //  Session.GetSessionInstance().thisConn     diyerek erişebilirsin artık.Singleton object yapısı   bilirsin zaten..

        // SqlCommand sorgu = new SqlCommand("SELECT Kul_Ad,Kul_Sifre FROM Users", SqlBaglan.OrneginiGetir());

    }
}
