using Reporting.DAL.Abstract.Dapper;

namespace Reporting.DAL.Concrete.Dapper
{

    public class ServiceBaseDapper
    {
        protected readonly IContext _context;

        public ServiceBaseDapper(IContext context)
        {
            _context = context;
        }
    }
}


