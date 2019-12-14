using Reporting.DAL;
using Reporting.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.BLL
{
    public class CallRepositoryUnitOfWork
    {



        GenericUnitOfWorkMessage msg = new GenericUnitOfWorkMessage();

        public void CallRepositoryUnitOfWorkCreateMessage()
        {
            msg.CreateMessage();

        }

        
       


    }
}
