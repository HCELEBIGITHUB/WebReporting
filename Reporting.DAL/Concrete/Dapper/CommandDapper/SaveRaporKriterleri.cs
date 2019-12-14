using Reporting.DAL.Abstract.Dapper;
using Reporting.Entities.Model;
namespace Reporting.DAL.Concrete.Dapper.CommandDapper
{
    public class SaveRaporKriterleri : ICommand
    {
        private readonly RAPOR_KRITERLERI_HIDIR _raporKriterleri;

        public SaveRaporKriterleri(RAPOR_KRITERLERI_HIDIR raporKriterleri)
        {
            _raporKriterleri = raporKriterleri;
        }

        public void Execute(IConnection connection)
        {
            if (_raporKriterleri.ID > 0)
            {
                //connection.Execute("UPDATE Suppliers SET CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle, Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country, Phone = @Phone, Fax = @Fax, HomePage = @HomePage WHERE Id = @SupplierId",
                //    new { _raporKriterleri.ID, _raporKriterleri.ACIKLAMA, _supplier.ContactName, _supplier.ContactTitle, _supplier.Address, _supplier.City, _supplier.Region, _supplier.PostalCode, _supplier.Country, _supplier.Phone, _supplier.Fax, _supplier.HomePage });

                connection.Execute("UPDATE RAPOR_KRITERLERI_HIDIR k SET k.ACIKLAMA = @ACIKLAMA,k.USER_ID=@USER_ID WHERE k.ID = @ID",
                new { _raporKriterleri.ID, _raporKriterleri.ACIKLAMA, _raporKriterleri.USER_ID });


                return;
            }

            //connection.Execute("INSERT INTO Suppliers (CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage) VALUES (@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@Phone,@Fax,@HomePage)",
            //    new { _supplier.CompanyName, _supplier.ContactName, _supplier.ContactTitle, _supplier.Address, _supplier.City, _supplier.Region, _supplier.PostalCode, _supplier.Country, _supplier.Phone, _supplier.Fax, _supplier.HomePage });

            connection.Execute("INSERT INTO RAPOR_KRITERLERI_HIDIR (ACIKLAMA,USER_ID) VALUES (@ACIKLAMA,@USER_ID)",
             new { _raporKriterleri.ACIKLAMA, _raporKriterleri.USER_ID });


        }
    }
}





