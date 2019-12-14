using Reporting.DAL.Abstract;
using Reporting.DAL.Concrete.EntityFramework;
using Reporting.Entities.Model;
using System;
using System.Web;

namespace Reporting.DAL.Concrete
{
    public class GenericUnitOfWorkMessage
    {

        public void CreateMessage()
        {

            //DataBaseInitializer<MessageContext>.InitializedDatabase();

            using (BaseContext context = ContextFactory.Create())
            {
                IUnitOfWork uow = new EFUnitOfWork(context);

                IRepositoryGeneric<User> userRepository = uow.GetRepository<User>();//Veri tabanımızı oluşturuyoruz. Varsa default değerleri de insertliyoruz.
                User user1 = new User() { Name = "Berkay" };
                User user2 = new User() { Name = "Arda" };
                userRepository.Add(user1);
                userRepository.Add(user2);

                uow.SaveChanges();

                IRepositoryGeneric<Message> msgRepository = uow.GetRepository<Message>();
                msgRepository.Add(new Message() { FromUser = user1, ToUser = user2, Text = $"Selam. Nasılsın?", CreateDate = DateTime.Now });
                msgRepository.Add(new Message() { FromUser = user2, ToUser = user1, Text = $"İyiyim", CreateDate = DateTime.Now });
                uow.SaveChanges();

                Console.WriteLine("Tüm mesajlar cekiliyor...");
                foreach (var msg in msgRepository.GetAll())
                {
                    Console.WriteLine(msg.ToString());
                    System.Diagnostics.Debug.WriteLine(msg.Text.ToString());
                    HttpContext.Current.Response.Write(msg.Text.ToString());
                }

                Console.WriteLine("Berkay'ın mesajları çekiliyor");
                foreach (var msg in msgRepository.GetAll((m) => m.FromUser.Name == "Berkay"))
                {
                    Console.WriteLine(msg.ToString());
                    System.Diagnostics.Debug.WriteLine(msg.Text.ToString());
                    HttpContext.Current.Response.Write(msg.Text.ToString());
                }


            }



        }


    }
}
