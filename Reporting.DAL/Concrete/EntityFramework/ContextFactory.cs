namespace Reporting.DAL.Concrete.EntityFramework
{
    public class ContextFactory
    {

        public static BaseContext Create()
        {
            //Eski hali
            return new MessageContext();

        }

    }
}



